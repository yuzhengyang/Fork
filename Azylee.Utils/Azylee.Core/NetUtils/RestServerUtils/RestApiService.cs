using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Azylee.Core.NetUtils.RestServerUtils
{
    /// <summary>
    /// REST API 服务类，支持 GET/POST 请求处理
    /// </summary>
    public class RestApiService : IDisposable
    {
        private readonly HttpListener _httpListener;
        private readonly Thread _listenerThread;
        private readonly Dictionary<string, Func<HttpListenerRequest, string>> _getRoutes;
        private readonly Dictionary<string, Func<HttpListenerRequest, string>> _postRoutes;
        private bool _isRunning;

        /// <summary>
        /// API服务是否正在运行
        /// </summary>
        public bool IsRunning
        {
            get { return _isRunning; }
        }

        /// <summary>
        /// API服务监听的URL前缀
        /// </summary>
        public string UrlPrefix { get; private set; }

        /// <summary>
        /// 发生未处理异常时触发的事件
        /// </summary>
        public event EventHandler<ExceptionEventArgs> Error;

        /// <summary>
        /// 初始化REST API服务
        /// </summary>
        /// <param name="urlPrefix">监听的URL前缀，例如 "http://localhost:5000/"</param>
        public RestApiService(string urlPrefix = "http://localhost:5000/")
        {
            UrlPrefix = urlPrefix;
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(urlPrefix);

            _getRoutes = new Dictionary<string, Func<HttpListenerRequest, string>>();
            _postRoutes = new Dictionary<string, Func<HttpListenerRequest, string>>();

            _listenerThread = new Thread(HandleRequests);
            _listenerThread.IsBackground = true;

            // 添加默认路由示例
            MapGet("/api/hello", req => "Hello from WinForm API!");
            MapGet("/api/time", req => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            MapPost("/api/echo", req =>
            {
                using (var reader = new System.IO.StreamReader(req.InputStream, req.ContentEncoding))
                {
                    return "Echo: " + reader.ReadToEnd();
                }
            });
        }

        /// <summary>
        /// 映射GET请求处理函数
        /// </summary>
        /// <param name="route">路由路径</param>
        /// <param name="handler">处理函数，接收HttpListenerRequest，返回响应字符串</param>
        public void MapGet(string route, Func<HttpListenerRequest, string> handler)
        {
            _getRoutes[route] = handler;
        }

        /// <summary>
        /// 映射POST请求处理函数
        /// </summary>
        /// <param name="route">路由路径</param>
        /// <param name="handler">处理函数，接收HttpListenerRequest，返回响应字符串</param>
        public void MapPost(string route, Func<HttpListenerRequest, string> handler)
        {
            _postRoutes[route] = handler;
        }

        /// <summary>
        /// 启动API服务
        /// </summary>
        public void Start()
        {
            if (_isRunning) return;

            try
            {
                _httpListener.Start();
                _isRunning = true;
                _listenerThread.Start();
            }
            catch (Exception ex)
            {
                _isRunning = false;
                OnError(ex);
                throw;
            }
        }

        /// <summary>
        /// 停止API服务
        /// </summary>
        public void Stop()
        {
            if (!_isRunning) return;

            try
            {
                _isRunning = false;
                _httpListener.Stop();
                _httpListener.Close();

                if (_listenerThread.IsAlive)
                {
                    _listenerThread.Abort();
                }
            }
            catch (Exception ex)
            {
                OnError(ex);
                throw;
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Stop();
                if (_httpListener != null)
                {
                    (_httpListener as IDisposable).Dispose();
                }
            }
        }

        private void HandleRequests()
        {
            while (_isRunning)
            {
                try
                {
                    var context = _httpListener.GetContext();
                    ProcessRequest(context);
                }
                catch (HttpListenerException)
                {
                    // 服务停止时会抛出此异常
                    break;
                }
                catch (ThreadAbortException)
                {
                    // 线程中止时会抛出此异常
                    break;
                }
                catch (Exception ex)
                {
                    OnError(ex);
                }
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            try
            {
                string responseString = "未找到匹配的路由";
                response.StatusCode = (int)HttpStatusCode.NotFound;

                // 处理GET请求
                if (request.HttpMethod == "GET" &&
                    _getRoutes.ContainsKey(request.Url.AbsolutePath))
                {
                    responseString = _getRoutes[request.Url.AbsolutePath](request);
                    response.StatusCode = (int)HttpStatusCode.OK;
                }
                // 处理POST请求
                else if (request.HttpMethod == "POST" &&
                         _postRoutes.ContainsKey(request.Url.AbsolutePath))
                {
                    responseString = _postRoutes[request.Url.AbsolutePath](request);
                    response.StatusCode = (int)HttpStatusCode.OK;
                }

                // 返回响应
                var buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                response.ContentType = "text/plain";
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var buffer = Encoding.UTF8.GetBytes("错误: " + ex.Message);
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);

                OnError(ex);
            }
            finally
            {
                response.OutputStream.Close();
            }
        }

        protected virtual void OnError(Exception ex)
        {
            var handler = Error;
            if (handler != null)
            {
                handler(this, new ExceptionEventArgs(ex));
            }
        }
    }

    /// <summary>
    /// 异常事件参数类
    /// </summary>
    public class ExceptionEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }

        public ExceptionEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}

