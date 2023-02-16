using Palink.Tools.IO;
using Palink.Tools.Logging;
using Palink.Tools.Robots.Old.LQ;
using Palink.Tools.Robots.Old.UPS;
using Palink.Tools.Robots.Old.YzAim;

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

    /// <summary>
    /// YzAim直流伺服控制
    /// </summary>
    /// <param name="streamResource"></param>
    /// <param name="logger"></param>
    /// <param name="retries">重试次数</param>
    /// <param name="waitToRetryMilliseconds">重试等待时间</param>
    /// <returns></returns>
    public static YzAimMaster CreateYzAimMaster(IStreamResource streamResource,
        IFreebusLogger logger, ushort? retries = 3,
        ushort? waitToRetryMilliseconds = 50)
    {
        var transport = new YzAimTransport(streamResource, logger);
        if (retries.HasValue)
            transport.Retries = retries.Value;
        if (waitToRetryMilliseconds.HasValue)
            transport.WaitToRetryMilliseconds = waitToRetryMilliseconds.Value;
        return new YzAimMaster(transport);
    }

    /// <summary>
    /// 山特UPS控制
    /// </summary>
    /// <param name="streamResource"></param>
    /// <param name="logger"></param>
    /// <param name="retries">重试次数</param>
    /// <param name="waitToRetryMilliseconds">重试等待时间</param>
    /// <returns></returns>
    public static SanTakUPSMaster CreateSanTakUPSMaster(IStreamResource streamResource,
        IFreebusLogger logger, ushort? retries = 3,
        ushort? waitToRetryMilliseconds = 50)
    {
        var transport = new UPSTransport(streamResource, logger);
        if (retries.HasValue)
            transport.Retries = retries.Value;
        if (waitToRetryMilliseconds.HasValue)
            transport.WaitToRetryMilliseconds = waitToRetryMilliseconds.Value;
        return new SanTakUPSMaster(transport);
    }

    /// <summary>
    /// 商业UPS控制
    /// </summary>
    /// <param name="streamResource"></param>
    /// <param name="logger"></param>
    /// <param name="retries">重试次数</param>
    /// <param name="waitToRetryMilliseconds">重试等待时间</param>
    /// <returns></returns>
    public static CPSYUPSMaster CreateCPSYUPSMaster(IStreamResource streamResource,
        IFreebusLogger logger, ushort? retries = 3,
        ushort? waitToRetryMilliseconds = 50)
    {
        var transport = new UPSTransport(streamResource, logger);
        if (retries.HasValue)
            transport.Retries = retries.Value;
        if (waitToRetryMilliseconds.HasValue)
            transport.WaitToRetryMilliseconds = waitToRetryMilliseconds.Value;
        return new CPSYUPSMaster(transport);
    }
}