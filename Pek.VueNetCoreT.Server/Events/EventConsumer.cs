using System.Reflection;

using NewLife.Log;

using Pek.Events;
using Pek.NCube.Events;
using Pek.NCubeUI.Events;

namespace Pek.VueNetCoreT.Server.Events;

public class EventConsumer :
    IConsumer<ModelPreparedEvent<BaseDHModel>>,
    IConsumer<ModelPreparedEvent<IEnumerable<BaseDHModel>>>,
    IConsumer<ModelPreparedEvent<BasePekModel>>,
    IConsumer<ModelPreparedEvent<IEnumerable<BasePekModel>>>,
    IConsumer<ModelReceivedEvent<BaseDHModel>>,
    IConsumer<ModelReceivedEvent<IEnumerable<BaseDHModel>>>,
    IConsumer<ModelReceivedEvent<BasePekModel>>,
    IConsumer<ModelReceivedEvent<IEnumerable<BasePekModel>>>,
    IConsumer<GenericRoutingEvent>
{

    public int Sort { get; set; } = 0;

    public async Task HandleEventAsync(ModelPreparedEvent<BaseDHModel> eventMessage)
    {
        XTrace.WriteLine($"进来这里了么？ModelPreparedEvent<BaseDHModel>");
    }

    public async Task HandleEventAsync(ModelPreparedEvent<IEnumerable<BaseDHModel>> eventMessage)
    {
        XTrace.WriteLine($"进来这里了么？ModelPreparedEvent<IEnumerable<BaseDHModel>>");
    }

    public async Task HandleEventAsync(ModelPreparedEvent<BasePekModel> eventMessage)
    {
        XTrace.WriteLine($"进来这里了么？ModelPreparedEvent<BasePekModel>");
    }

    public async Task HandleEventAsync(ModelPreparedEvent<IEnumerable<BasePekModel>> eventMessage)
    {
        XTrace.WriteLine($"进来这里了么？ModelPreparedEvent<IEnumerable<BasePekModel>>");
    }

    public async Task HandleEventAsync(GenericRoutingEvent eventMessage)
    {
        XTrace.WriteLine($"进来GenericRoutingConsumer");

        //eventMessage.Handled = true;

        await Task.CompletedTask;
    }

    public async Task HandleEventAsync(ModelReceivedEvent<BaseDHModel> eventMessage)
    {
        XTrace.WriteLine($"进来这里了么？ModelReceivedEvent<BaseDHModel>");
    }

    public async Task HandleEventAsync(ModelReceivedEvent<BasePekModel> eventMessage)
    {
        XTrace.WriteLine($"进来这里了么？ModelReceivedEvent<BasePekModel>");
    }

    public async Task HandleEventAsync(ModelReceivedEvent<IEnumerable<BaseDHModel>> eventMessage)
    {
        XTrace.WriteLine($"进来这里了么？ModelReceivedEvent<IEnumerable<BaseDHModel>>");
    }

    public async Task HandleEventAsync(ModelReceivedEvent<IEnumerable<BasePekModel>> eventMessage)
    {
        XTrace.WriteLine($"进来这里了么？ModelReceivedEvent<IEnumerable<BaseDHModel>>");
    }
}