using Palink.Tools.IO;
using Palink.Tools.Logging;
using Palink.Tools.Robots.Old.LQ;

namespace Palink.Tools.Robots.Old;

public class RobotsFactory
{
    /// <summary>
    /// 李群机械臂控制
    /// </summary>
    /// <param name="streamResource"></param>
    /// <param name="logger"></param>
    /// <param name="retries">重试次数</param>
    /// <param name="waitToRetryMilliseconds">重试等待时间</param>
    /// <returns></returns>
    public static LQMaster CreateLQMaster(IStreamResource streamResource,
        IFreebusLogger logger, ushort? retries = 3,
        ushort? waitToRetryMilliseconds = 50)
    {
        var transport = new LQTransport(streamResource, logger);
        if (retries.HasValue)
            transport.Retries = retries.Value;
        if (waitToRetryMilliseconds.HasValue)
            transport.WaitToRetryMilliseconds = waitToRetryMilliseconds.Value;
        return new LQMaster(transport);
    }
}