using Palink.Tools.IO;
using Palink.Tools.Logging;
using Palink.Tools.Robots.Epson;

namespace Palink.Tools.Robots;

public class RobotsFactory
{
    /// <summary>
    /// 爱普生机械臂控制
    /// </summary>
    /// <param name="streamResource"></param>
    /// <param name="logger"></param>
    /// <param name="retries">重试次数</param>
    /// <param name="waitToRetryMilliseconds">重试等待时间</param>
    /// <returns></returns>
    public static EpsonMaster CreateEpsonMaster(IStreamResource streamResource,
        IFreebusLogger logger, ushort? retries = 3,
        ushort? waitToRetryMilliseconds = 50)
    {
        var transport = new EpsonTransport(streamResource, logger);
        if (retries.HasValue)
            transport.Retries = retries.Value;
        if (waitToRetryMilliseconds.HasValue)
            transport.WaitToRetryMilliseconds = waitToRetryMilliseconds.Value;
        return new EpsonMaster(transport);
    }
}