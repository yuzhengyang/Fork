using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.BigBirdDeployer.Models
{
    enum WorkStatus
    {
        准备就绪 = 0,
        启动成功 = 1,

        正在启动 = 101,
        正在关闭 = 102,

        端口占用 = 401,

        启动失败 = 901,//未知原因
    }
}
