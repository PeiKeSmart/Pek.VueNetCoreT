using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using NewLife;
using NewLife.Data;
using XCode;
using XCode.Cache;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Pek.Entity;

/// <summary>系统角色表</summary>
[Serializable]
[DataObject]
[Description("系统角色表")]
[BindIndex("IX_DH_SysRole_Name", false, "Name")]
[BindIndex("IX_DH_SysRole_ParentId", false, "ParentId")]
[BindIndex("IX_DH_SysRole_DeleteBy", false, "DeleteBy")]
[BindTable("DH_SysRole", Description = "系统角色表", ConnName = "Pek", DbType = DatabaseType.None)]
public partial class SysRole : ISysRole, IEntity<ISysRole>
{
    #region 属性
    private Int32 _Id;
    /// <summary>编号</summary>
    [DisplayName("编号")]
    [Description("编号")]
    [DataObjectField(true, true, false, 0)]
    [BindColumn("Id", "编号", "")]
    public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

    private String _Name = null!;
    /// <summary>菜单名称</summary>
    [DisplayName("菜单名称")]
    [Description("菜单名称")]
    [DataObjectField(false, false, false, 50)]
    [BindColumn("Name", "菜单名称", "", Master = true)]
    public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

    private String? _DeptName;
    /// <summary>部门名称</summary>
    [DisplayName("部门名称")]
    [Description("部门名称")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("DeptName", "部门名称", "")]
    public String? DeptName { get => _DeptName; set { if (OnPropertyChanging("DeptName", value)) { _DeptName = value; OnPropertyChanged("DeptName"); } } }

    private Int32 _DeptId;
    /// <summary>部门编号</summary>
    [DisplayName("部门编号")]
    [Description("部门编号")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("DeptId", "部门编号", "")]
    public Int32 DeptId { get => _DeptId; set { if (OnPropertyChanging("DeptId", value)) { _DeptId = value; OnPropertyChanged("DeptId"); } } }

    private Boolean _Enable;
    /// <summary>是否启用</summary>
    [DisplayName("是否启用")]
    [Description("是否启用")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("Enable", "是否启用", "")]
    public Boolean Enable { get => _Enable; set { if (OnPropertyChanging("Enable", value)) { _Enable = value; OnPropertyChanged("Enable"); } } }

    private Int32 _OrderNo;
    /// <summary>排序号</summary>
    [DisplayName("排序号")]
    [Description("排序号")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("OrderNo", "排序号", "")]
    public Int32 OrderNo { get => _OrderNo; set { if (OnPropertyChanging("OrderNo", value)) { _OrderNo = value; OnPropertyChanged("OrderNo"); } } }

    private Int32 _ParentId;
    /// <summary>父级角色ID</summary>
    [DisplayName("父级角色ID")]
    [Description("父级角色ID")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("ParentId", "父级角色ID", "")]
    public Int32 ParentId { get => _ParentId; set { if (OnPropertyChanging("ParentId", value)) { _ParentId = value; OnPropertyChanged("ParentId"); } } }

    private String? _DeleteBy;
    /// <summary>删除该角色的用户（软删除标记）</summary>
    [DisplayName("删除该角色的用户（软删除标记）")]
    [Description("删除该角色的用户（软删除标记）")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("DeleteBy", "删除该角色的用户（软删除标记）", "")]
    public String? DeleteBy { get => _DeleteBy; set { if (OnPropertyChanging("DeleteBy", value)) { _DeleteBy = value; OnPropertyChanged("DeleteBy"); } } }

    private String? _CreateUser;
    /// <summary>创建者</summary>
    [DisplayName("创建者")]
    [Description("创建者")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("CreateUser", "创建者", "")]
    public String? CreateUser { get => _CreateUser; set { if (OnPropertyChanging("CreateUser", value)) { _CreateUser = value; OnPropertyChanged("CreateUser"); } } }

    private Int32 _CreateUserID;
    /// <summary>创建者</summary>
    [DisplayName("创建者")]
    [Description("创建者")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("CreateUserID", "创建者", "")]
    public Int32 CreateUserID { get => _CreateUserID; set { if (OnPropertyChanging("CreateUserID", value)) { _CreateUserID = value; OnPropertyChanged("CreateUserID"); } } }

    private DateTime _CreateTime;
    /// <summary>创建时间</summary>
    [DisplayName("创建时间")]
    [Description("创建时间")]
    [DataObjectField(false, false, true, 0)]
    [BindColumn("CreateTime", "创建时间", "")]
    public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

    private String? _CreateIP;
    /// <summary>创建地址</summary>
    [DisplayName("创建地址")]
    [Description("创建地址")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("CreateIP", "创建地址", "")]
    public String? CreateIP { get => _CreateIP; set { if (OnPropertyChanging("CreateIP", value)) { _CreateIP = value; OnPropertyChanged("CreateIP"); } } }

    private String? _UpdateUser;
    /// <summary>更新者</summary>
    [DisplayName("更新者")]
    [Description("更新者")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("UpdateUser", "更新者", "")]
    public String? UpdateUser { get => _UpdateUser; set { if (OnPropertyChanging("UpdateUser", value)) { _UpdateUser = value; OnPropertyChanged("UpdateUser"); } } }

    private Int32 _UpdateUserID;
    /// <summary>更新者</summary>
    [DisplayName("更新者")]
    [Description("更新者")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("UpdateUserID", "更新者", "")]
    public Int32 UpdateUserID { get => _UpdateUserID; set { if (OnPropertyChanging("UpdateUserID", value)) { _UpdateUserID = value; OnPropertyChanged("UpdateUserID"); } } }

    private DateTime _UpdateTime;
    /// <summary>更新时间</summary>
    [DisplayName("更新时间")]
    [Description("更新时间")]
    [DataObjectField(false, false, true, 0)]
    [BindColumn("UpdateTime", "更新时间", "")]
    public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

    private String? _UpdateIP;
    /// <summary>更新地址</summary>
    [DisplayName("更新地址")]
    [Description("更新地址")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("UpdateIP", "更新地址", "")]
    public String? UpdateIP { get => _UpdateIP; set { if (OnPropertyChanging("UpdateIP", value)) { _UpdateIP = value; OnPropertyChanged("UpdateIP"); } } }
    #endregion

    #region 拷贝
    /// <summary>拷贝模型对象</summary>
    /// <param name="model">模型</param>
    public void Copy(ISysRole model)
    {
        Id = model.Id;
        Name = model.Name;
        DeptName = model.DeptName;
        DeptId = model.DeptId;
        Enable = model.Enable;
        OrderNo = model.OrderNo;
        ParentId = model.ParentId;
        DeleteBy = model.DeleteBy;
        CreateUser = model.CreateUser;
        CreateUserID = model.CreateUserID;
        CreateTime = model.CreateTime;
        CreateIP = model.CreateIP;
        UpdateUser = model.UpdateUser;
        UpdateUserID = model.UpdateUserID;
        UpdateTime = model.UpdateTime;
        UpdateIP = model.UpdateIP;
    }
    #endregion

    #region 获取/设置 字段值
    /// <summary>获取/设置 字段值</summary>
    /// <param name="name">字段名</param>
    /// <returns></returns>
    public override Object? this[String name]
    {
        get => name switch
        {
            "Id" => _Id,
            "Name" => _Name,
            "DeptName" => _DeptName,
            "DeptId" => _DeptId,
            "Enable" => _Enable,
            "OrderNo" => _OrderNo,
            "ParentId" => _ParentId,
            "DeleteBy" => _DeleteBy,
            "CreateUser" => _CreateUser,
            "CreateUserID" => _CreateUserID,
            "CreateTime" => _CreateTime,
            "CreateIP" => _CreateIP,
            "UpdateUser" => _UpdateUser,
            "UpdateUserID" => _UpdateUserID,
            "UpdateTime" => _UpdateTime,
            "UpdateIP" => _UpdateIP,
            _ => base[name]
        };
        set
        {
            switch (name)
            {
                case "Id": _Id = value.ToInt(); break;
                case "Name": _Name = Convert.ToString(value); break;
                case "DeptName": _DeptName = Convert.ToString(value); break;
                case "DeptId": _DeptId = value.ToInt(); break;
                case "Enable": _Enable = value.ToBoolean(); break;
                case "OrderNo": _OrderNo = value.ToInt(); break;
                case "ParentId": _ParentId = value.ToInt(); break;
                case "DeleteBy": _DeleteBy = Convert.ToString(value); break;
                case "CreateUser": _CreateUser = Convert.ToString(value); break;
                case "CreateUserID": _CreateUserID = value.ToInt(); break;
                case "CreateTime": _CreateTime = value.ToDateTime(); break;
                case "CreateIP": _CreateIP = Convert.ToString(value); break;
                case "UpdateUser": _UpdateUser = Convert.ToString(value); break;
                case "UpdateUserID": _UpdateUserID = value.ToInt(); break;
                case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                case "UpdateIP": _UpdateIP = Convert.ToString(value); break;
                default: base[name] = value; break;
            }
        }
    }
    #endregion

    #region 关联映射
    #endregion

    #region 扩展查询
    /// <summary>根据编号查找</summary>
    /// <param name="id">编号</param>
    /// <returns>实体对象</returns>
    public static SysRole? FindById(Int32 id)
    {
        if (id < 0) return null;

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Id == id);

        // 单对象缓存
        return Meta.SingleCache[id];

        //return Find(_.Id == id);
    }

    /// <summary>根据菜单名称查找</summary>
    /// <param name="name">菜单名称</param>
    /// <returns>实体列表</returns>
    public static IList<SysRole> FindAllByName(String name)
    {
        if (name.IsNullOrEmpty()) return [];

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.Name.EqualIgnoreCase(name));

        return FindAll(_.Name == name);
    }

    /// <summary>根据父级角色ID查找</summary>
    /// <param name="parentId">父级角色ID</param>
    /// <returns>实体列表</returns>
    public static IList<SysRole> FindAllByParentId(Int32 parentId)
    {
        if (parentId < 0) return [];

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.ParentId == parentId);

        return FindAll(_.ParentId == parentId);
    }

    /// <summary>根据删除该角色的用户（软删除标记）查找</summary>
    /// <param name="deleteBy">删除该角色的用户（软删除标记）</param>
    /// <returns>实体列表</returns>
    public static IList<SysRole> FindAllByDeleteBy(String? deleteBy)
    {
        if (deleteBy == null) return [];

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.DeleteBy.EqualIgnoreCase(deleteBy));

        return FindAll(_.DeleteBy == deleteBy);
    }
    #endregion

    #region 字段名
    /// <summary>取得系统角色表字段信息的快捷方式</summary>
    public partial class _
    {
        /// <summary>编号</summary>
        public static readonly Field Id = FindByName("Id");

        /// <summary>菜单名称</summary>
        public static readonly Field Name = FindByName("Name");

        /// <summary>部门名称</summary>
        public static readonly Field DeptName = FindByName("DeptName");

        /// <summary>部门编号</summary>
        public static readonly Field DeptId = FindByName("DeptId");

        /// <summary>是否启用</summary>
        public static readonly Field Enable = FindByName("Enable");

        /// <summary>排序号</summary>
        public static readonly Field OrderNo = FindByName("OrderNo");

        /// <summary>父级角色ID</summary>
        public static readonly Field ParentId = FindByName("ParentId");

        /// <summary>删除该角色的用户（软删除标记）</summary>
        public static readonly Field DeleteBy = FindByName("DeleteBy");

        /// <summary>创建者</summary>
        public static readonly Field CreateUser = FindByName("CreateUser");

        /// <summary>创建者</summary>
        public static readonly Field CreateUserID = FindByName("CreateUserID");

        /// <summary>创建时间</summary>
        public static readonly Field CreateTime = FindByName("CreateTime");

        /// <summary>创建地址</summary>
        public static readonly Field CreateIP = FindByName("CreateIP");

        /// <summary>更新者</summary>
        public static readonly Field UpdateUser = FindByName("UpdateUser");

        /// <summary>更新者</summary>
        public static readonly Field UpdateUserID = FindByName("UpdateUserID");

        /// <summary>更新时间</summary>
        public static readonly Field UpdateTime = FindByName("UpdateTime");

        /// <summary>更新地址</summary>
        public static readonly Field UpdateIP = FindByName("UpdateIP");

        static Field FindByName(String name) => Meta.Table.FindByName(name);
    }

    /// <summary>取得系统角色表字段名称的快捷方式</summary>
    public partial class __
    {
        /// <summary>编号</summary>
        public const String Id = "Id";

        /// <summary>菜单名称</summary>
        public const String Name = "Name";

        /// <summary>部门名称</summary>
        public const String DeptName = "DeptName";

        /// <summary>部门编号</summary>
        public const String DeptId = "DeptId";

        /// <summary>是否启用</summary>
        public const String Enable = "Enable";

        /// <summary>排序号</summary>
        public const String OrderNo = "OrderNo";

        /// <summary>父级角色ID</summary>
        public const String ParentId = "ParentId";

        /// <summary>删除该角色的用户（软删除标记）</summary>
        public const String DeleteBy = "DeleteBy";

        /// <summary>创建者</summary>
        public const String CreateUser = "CreateUser";

        /// <summary>创建者</summary>
        public const String CreateUserID = "CreateUserID";

        /// <summary>创建时间</summary>
        public const String CreateTime = "CreateTime";

        /// <summary>创建地址</summary>
        public const String CreateIP = "CreateIP";

        /// <summary>更新者</summary>
        public const String UpdateUser = "UpdateUser";

        /// <summary>更新者</summary>
        public const String UpdateUserID = "UpdateUserID";

        /// <summary>更新时间</summary>
        public const String UpdateTime = "UpdateTime";

        /// <summary>更新地址</summary>
        public const String UpdateIP = "UpdateIP";
    }
    #endregion
}
