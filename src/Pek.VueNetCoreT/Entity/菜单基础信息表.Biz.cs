using System.ComponentModel;

using NewLife;
using NewLife.Data;
using NewLife.Log;

using XCode;

namespace Pek.Entity;

public partial class SysMenu : CubeEntityBase<SysMenu>
{
    #region 对象操作
    static SysMenu()
    {
        // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
        //var df = Meta.Factory.AdditionalFields;
        //df.Add(nameof(OrderNo));

        // 过滤器 UserModule、TimeModule、IPModule
        Meta.Modules.Add(new UserModule { AllowEmpty = false });
        Meta.Modules.Add<TimeModule>();
        Meta.Modules.Add(new IPModule { AllowEmpty = false });

        // 实体缓存
        // var ec = Meta.Cache;
        // ec.Expire = 60;
    }

    /// <summary>验证并修补数据，返回验证结果，或者通过抛出异常的方式提示验证失败。</summary>
    /// <param name="method">添删改方法</param>
    public override Boolean Valid(DataMethod method)
    {
        //if (method == DataMethod.Delete) return true;
        // 如果没有脏数据，则不需要进行任何处理
        if (!HasDirty) return true;

        // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
        if (Name.IsNullOrEmpty()) throw new ArgumentNullException(nameof(Name), "菜单名称不能为空！");

        // 建议先调用基类方法，基类方法会做一些统一处理
        if (!base.Valid(method)) return false;

        // 在新插入数据或者修改了指定字段时进行修正

        // 处理当前已登录用户信息，可以由UserModule过滤器代劳
        /*var user = ManageProvider.User;
        if (user != null)
        {
            if (method == DataMethod.Insert && !Dirtys[nameof(CreateUserID)]) CreateUserID = user.ID;
            if (!Dirtys[nameof(UpdateUserID)]) UpdateUserID = user.ID;
        }*/
        //if (method == DataMethod.Insert && !Dirtys[nameof(CreateTime)]) CreateTime = DateTime.Now;
        //if (!Dirtys[nameof(UpdateTime)]) UpdateTime = DateTime.Now;
        //if (method == DataMethod.Insert && !Dirtys[nameof(CreateIP)]) CreateIP = ManageProvider.UserHost;
        //if (!Dirtys[nameof(UpdateIP)]) UpdateIP = ManageProvider.UserHost;

        return true;
    }

    /// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected override void InitData()
{
    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
    if (Meta.Session.Count > 0) return;

    if (XTrace.Debug) XTrace.WriteLine("开始初始化SysMenu[菜单基础信息表]数据……");

    var list = new List<SysMenu>
    {
        AddMenu(2, "用户管理", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-user", null, true, 9000, ".", 61, null, 0),
        AddMenu(3, "角色管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 900, "Sys_Role", 2, "/Sys_Role", 0),
        AddMenu(5, "日志管理", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-date", null, true, 1300, "xxx", 61, "/", 0),
        AddMenu(6, "系统日志", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 0, "Sys_Log", 5, "/Sys_Log/Manager", 0),
        AddMenu(8, "图表开发", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-monitor", null, true, 10000, ".", 32, "/ProductionState", 0),
        AddMenu(9, "用户管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导入\",\"value\":\"Import\"},{\"text\":\"导出\",\"value\":\"Export\"},{\"text\":\"上传\",\"value\":\"Upload\"},{\"text\":\"审核\",\"value\":\"Audit\"}]", "", null, true, 2000, "Sys_User", 2, "/Sys_User", 0),
        AddMenu(32, "基础组件", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-full-screen", null, true, 1720, "/", 0, "", 0),
        AddMenu(36, "图表+表单", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-data-analysis", null, true, 900, "/", 32, "formChart", 0),
        AddMenu(45, "不用节点", "", "", null, false, 0, "/", 0, null, 0),
        AddMenu(61, "系统设置", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-setting", null, true, 1000, "系统设置", 0, "/", 0),
        AddMenu(62, "菜单设置", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "", null, true, 8000, "Sys_Menu", 291, "/sysmenu", 0),
        AddMenu(63, "数据字典", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 7000, "Sys_Dictionary", 292, "/Sys_Dictionary", 0),
        AddMenu(64, "代码生成", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-paperclip", null, true, 1500, "代码生成", 61, "/coding", 0),
        AddMenu(65, "代码生成", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"}]", "", null, true, 10, "/", 64, "/coder", 0),
        AddMenu(71, "权限管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"编辑\",\"value\":\"Update\"}]", "ivu-icon ivu-icon-ios-boat", null, true, 1000, ",", 2, "/permission", 0),
        AddMenu(91, "图表+表格", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-odometer", null, true, 800, "数字排版", 32, "/flex", 0),
        AddMenu(104, "角色管理(tree)", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"}]", "", null, false, 0, "Sys_Role1", 2, "/Sys_Role1", 0),
        AddMenu(106, "表单设计", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-postcard", null, true, 3000, ".", 61, "", 0),
        AddMenu(107, "表单设计", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "", null, true, 100, ".", 106, "/formDraggable", 0),
        AddMenu(109, "表单配置", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"}]", "", null, true, 0, "FormDesignOptions", 106, "/FormDesignOptions", 0),
        AddMenu(110, "数据采集", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 0, ".", 106, "/formCollectionResultTree", 0),
        AddMenu(113, "基础页面", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "", null, true, 9000, ".", 0, "", 1),
        AddMenu(115, "水平显示", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "", null, true, 0, ".", 113, "/pages/order/App_Appointment1/App_Appointment1", 1),
        AddMenu(125, "表单只读", "", "", null, true, 0, ".", 113, "pages/form/form1", 1),
        AddMenu(132, "消息推送", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-chat-line-round", null, true, 1700, ".", 293, "/signalR", 0),
        AddMenu(133, "审批管理", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-mobile", null, true, 6800, "流程管理", 61, "", 0),
        AddMenu(134, "流程管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 0, "Sys_WorkFlow", 133, "/Sys_WorkFlow", 0),
        AddMenu(135, "我的审批", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"删除\",\"value\":\"Delete\"}]", "", null, true, 0, "Sys_WorkFlowTable", 133, "/Sys_WorkFlowTable", 0),
        AddMenu(136, "发起流程", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "", null, true, 0, "发起流程", 133, "/flowdemo", 0),
        AddMenu(137, "定时任务", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-alarm-clock", null, true, 1725, "定时任务", 61, "", 0),
        AddMenu(138, "任务配置", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 0, "Sys_QuartzOptions", 137, "/Sys_QuartzOptions", 0),
        AddMenu(139, "执行记录", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 0, "Sys_QuartzLog", 137, "/Sys_QuartzLog", 0),
        AddMenu(142, "组织架构", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 2500, "Sys_Department", 2, "/Sys_Department", 0),
        AddMenu(235, "MES业务", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-monitor", null, true, 9000, ".", 0, "", 0),
        AddMenu(236, "基础设置", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-receiving", null, true, 2000, ".", 235, "", 0),
        AddMenu(237, "仓库管理", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-house", null, true, 1800, ".", 235, "", 0),
        AddMenu(238, "设备管理", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-news", null, true, 1600, ".", 235, "", 0),
        AddMenu(239, "生产计划", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-shopping-cart-1", null, true, 1400, ".", 235, "", 0),
        AddMenu(240, "质检中心", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-edit-outline", null, true, 1200, ".", 235, "", 0),
        AddMenu(241, "工序管理", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-mobile-phone", null, true, 1500, ".", 235, "", 0),
        AddMenu(242, "生产排班", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-stopwatch", null, true, 1000, ".", 235, "", 0),
        AddMenu(244, "生产报工", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-tickets", null, true, 1300, ".", 235, "", 0),
        AddMenu(247, "审批流程", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-date", null, true, 2900, ".", 235, "", 0),
        AddMenu(249, " 客户管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"}]", "", null, true, 800, "MES_Customer", 236, "/MES_Customer", 0),
        AddMenu(250, "供应商", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"复制\",\"value\":\"CopyData\"},{\"text\":\"导入\",\"value\":\"Import\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 700, "MES_Supplier", 236, "/MES_Supplier", 0),
        AddMenu(251, "产线管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 600, "MES_ProductionLine", 236, "/MES_ProductionLine", 0),
        AddMenu(252, "产线设备", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "", null, false, 500, "MES_ProductionLineDevice", 236, "/MES_ProductionLineDevice", 0),
        AddMenu(253, "物料管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"打印\",\"value\":\"Print\"}]", "", null, true, 510, "MES_Material", 236, "/MES_Material", 0),
        AddMenu(254, "物料分类", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"}]", "", null, true, 550, "MES_MaterialCatalog", 236, "/MES_MaterialCatalog", 0),
        AddMenu(255, "仓库管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"复制\",\"value\":\"CopyData\"},{\"text\":\"导入\",\"value\":\"Import\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 900, "MES_WarehouseManagement", 237, "/MES_WarehouseManagement", 0),
        AddMenu(256, "货位管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"复制\",\"value\":\"CopyData\"},{\"text\":\"导入\",\"value\":\"Import\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 800, "MES_LocationManagement", 237, "/MES_LocationManagement", 0),
        AddMenu(257, "库存管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"复制\",\"value\":\"CopyData\"},{\"text\":\"导出\",\"value\":\"Export\"},{\"text\":\"打印\",\"value\":\"Print\"}]", "", null, true, 700, "MES_InventoryManagement", 237, "/MES_InventoryManagement", 0),
        AddMenu(258, "产品入库", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 600, "MES_ProductInbound", 237, "/MES_ProductInbound", 0),
        AddMenu(259, "产品出库", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 500, "MES_ProductOutbound", 237, "/MES_ProductOutbound", 0),
        AddMenu(260, "设备管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"}]", "", null, true, 900, "MES_EquipmentManagement", 238, "/MES_EquipmentManagement", 0),
        AddMenu(261, "设备维修", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导入\",\"value\":\"Import\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 800, "MES_EquipmentRepair", 238, "/MES_EquipmentRepair", 0),
        AddMenu(262, "设备保养", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 0, "MES_EquipmentMaintenance", 238, "/MES_EquipmentMaintenance", 0),
        AddMenu(263, "设备故障", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导入\",\"value\":\"Import\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 500, "MES_EquipmentFaultRecord", 238, "/MES_EquipmentFaultRecord", 0),
        AddMenu(264, "工序管理", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"复制\",\"value\":\"CopyData\"},{\"text\":\"打印\",\"value\":\"Print\"}]", "", null, true, 800, "MES_Process", 241, "/MES_Process", 0),
        AddMenu(265, "工线路线", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 700, "MES_ProcessRoute", 241, "/MES_ProcessRoute", 0),
        AddMenu(266, "工序统计", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"导出\",\"value\":\"Export\"},{\"text\":\"打印\",\"value\":\"Print\"}]", "", null, true, 600, "MES_ProcessReport", 241, "/MES_ProcessReport", 0),
        AddMenu(267, "生产订单", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"},{\"text\":\"打印\",\"value\":\"Print\"}]", "", null, true, 900, "MES_ProductionOrder", 239, "/MES_ProductionOrder", 0),
        AddMenu(268, "订单明细表", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"}]", "", null, false, 800, "MES_ProductionPlanDetail", 239, "/MES_ProductionPlanDetail", 0),
        AddMenu(270, "变更记录", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 600, "MES_ProductionPlanChangeRecord", 239, "/MES_ProductionPlanChangeRecord", 0),
        AddMenu(271, "生产报工", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"审核\",\"value\":\"Audit\"},{\"text\":\"反审\",\"value\":\"AntiAudit\"},{\"text\":\"打印\",\"value\":\"Print\"}]", "", null, true, 900, "MES_ProductionReporting", 244, "/MES_ProductionReporting", 0),
        AddMenu(272, "报工明细", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"}]", "", null, false, 800, "MES_ProductionReportingDetail", 244, "/MES_ProductionReportingDetail", 0),
        AddMenu(273, "生产不良记录", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 600, "MES_DefectiveProductRecord", 244, "/MES_DefectiveProductRecord", 0),
        AddMenu(275, "质量检验", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"复制\",\"value\":\"CopyData\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 900, "MES_QualityInspectionPlan", 240, "/MES_QualityInspectionPlan", 0),
        AddMenu(276, "质检明细", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"}]", "", null, false, 700, "MES_QualityInspectionPlanDetail", 240, "/MES_QualityInspectionPlanDetail", 0),
        AddMenu(277, "质检记录", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 500, "MES_QualityInspectionRecord", 240, "/MES_QualityInspectionRecord", 0),
        AddMenu(279, "排班计划", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"复制\",\"value\":\"CopyData\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 800, "MES_SchedulingPlan", 242, "/MES_SchedulingPlan", 0),
        AddMenu(280, "排班日历", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "", null, true, 600, ".", 242, "MES_Calendar", 0),
        AddMenu(281, "我的审批", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "", null, true, 800, ".", 247, "/Sys_WorkFlowTable", 0),
        AddMenu(282, "流程配置", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"}]", "", null, true, 700, ".", 247, "Sys_WorkFlow", 0),
        AddMenu(286, "制造BOM", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-setting", null, true, 1400, ".", 235, "", 0),
        AddMenu(287, "制造BOM", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"复制\",\"value\":\"CopyData\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, true, 200, "MES_Bom_Main", 286, "/MES_Bom_Main", 0),
        AddMenu(289, "生产任务", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "", null, true, 500, ".", 239, "/list", 0),
        AddMenu(290, "Bom明细", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导出\",\"value\":\"Export\"}]", "", null, false, 0, "MES_Bom_Detail", 286, "/MES_Bom_Detail", 0),
        AddMenu(291, "菜单设置", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-folder", null, true, 8100, ".", 61, "", 0),
        AddMenu(292, "数据字典", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-receiving", null, true, 7100, ".", 61, "", 0),
        AddMenu(293, "消息推送", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-chat-dot-round", null, true, 1800, ".", 61, "", 0),
        AddMenu(294, "统计报表", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-data-line", null, true, 700, ".", 235, "", 0),
        AddMenu(295, "生产统计", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "", null, true, 800, ".", 294, "/ProductionState", 0),
        AddMenu(296, "图表统计", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-data-line", null, true, 2000, ".", 32, "", 0),
        AddMenu(297, "多页签配置", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-receiving", null, true, 700, ".", 32, "", 0),
        AddMenu(298, "一对多配置", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-coin", null, true, 710, ".", 32, "", 0),
        AddMenu(299, "文本编辑", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-mobile-phone", null, true, 780, ".", 32, "", 0),
        AddMenu(300, "主从结构", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导入\",\"value\":\"Import\"}]", "el-icon-office-building", null, true, 760, ".", 32, "/MES_Process", 0),
        AddMenu(301, "树形结构", "[{\"text\":\"查询\",\"value\":\"Search\"},{\"text\":\"新建\",\"value\":\"Add\"},{\"text\":\"删除\",\"value\":\"Delete\"},{\"text\":\"编辑\",\"value\":\"Update\"},{\"text\":\"导入\",\"value\":\"Import\"}]", "el-icon-guide", null, true, 740, ".", 32, "/MES_Material", 0),
        AddMenu(302, "移动端开发", "[{\"text\":\"查询\",\"value\":\"Search\"}]", "el-icon-mobile-phone", null, true, 600, ".", 32, "http://app.volcore.xyz/", 0)
    };

    // 保存所有菜单
    list.Save();

    if (XTrace.Debug) XTrace.WriteLine("完成初始化SysMenu[菜单基础信息表]数据！");
}

    ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
    ///// <returns></returns>
    //public override Int32 Insert()
    //{
    //    return base.Insert();
    //}

    ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
    ///// <returns></returns>
    //protected override Int32 OnDelete()
    //{
    //    return base.OnDelete();
    //}
    #endregion

    #region 扩展属性
    #endregion

    #region 高级查询
    /// <summary>高级查询</summary>
    /// <param name="name">菜单名称</param>
    /// <param name="enable">是否启用</param>
    /// <param name="start">更新时间开始</param>
    /// <param name="end">更新时间结束</param>
    /// <param name="key">关键字</param>
    /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
    /// <returns>实体列表</returns>
    public static IList<SysMenu> Search(String name, Boolean? enable, DateTime start, DateTime end, String key, PageParameter page)
    {
        var exp = new WhereExpression();

        if (!name.IsNullOrEmpty()) exp &= _.Name == name;
        if (enable != null) exp &= _.Enable == enable;
        exp &= _.UpdateTime.Between(start, end);
        if (!key.IsNullOrEmpty()) exp &= SearchWhereByKeys(key);

        return FindAll(exp, page);
    }

    // Select Count(Id) as Id,Category From DH_SysMenu Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By Id Desc limit 20
    //static readonly FieldCache<SysMenu> _CategoryCache = new(nameof(Category))
    //{
    //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
    //};

    ///// <summary>获取类别列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
    ///// <returns></returns>
    //public static IDictionary<String, String> GetCategoryList() => _CategoryCache.FindAllName();
    #endregion

    #region 业务操作
    public ISysMenu ToModel()
    {
        var model = new SysMenu();
        model.Copy(this);

        return model;
    }

    public static SysMenu AddMenu(Int32 Id, String Name, String Auth, String Icon, String? Description, Boolean Enable, Int32 OrderNo, String TableName, Int32 ParentId, String? Url, Int32 MenuType)
    {
        var model = new SysMenu
        {
            Id = Id,
            Name = Name,
            Auth = Auth,
            Icon = Icon,
            Description = Description,
            Enable = Enable,
            OrderNo = OrderNo,
            TableName = TableName,
            ParentId = ParentId,
            Url = Url,
            MenuType = MenuType
        };

        return model;
    }

    #endregion
}
