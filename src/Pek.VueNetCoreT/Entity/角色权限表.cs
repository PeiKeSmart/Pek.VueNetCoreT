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

/// <summary>角色权限表</summary>
[Serializable]
[DataObject]
[Description("角色权限表")]
[BindIndex("IU_DH_SysRoleAuth_SysMenuId_RoleId", true, "SysMenuId,RoleId")]
[BindIndex("IU_DH_SysRoleAuth_SysMenuId_RoleId_UserId", true, "SysMenuId,RoleId,UserId")]
[BindTable("DH_SysRoleAuth", Description = "角色权限表", ConnName = "Pek", DbType = DatabaseType.None)]
public partial class SysRoleAuth : ISysRoleAuth, IEntity<ISysRoleAuth>
{
    #region 属性
    private Int32 _Id;
    /// <summary>编号</summary>
    [DisplayName("编号")]
    [Description("编号")]
    [DataObjectField(true, true, false, 0)]
    [BindColumn("Id", "编号", "")]
    public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

    private String? _AuthValue;
    /// <summary>存储具体的权限操作。如Search,Add,Delete,Update,Import,Export,Upload,Audit等，多个权限用逗号分隔</summary>
    [DisplayName("存储具体的权限操作")]
    [Description("存储具体的权限操作。如Search,Add,Delete,Update,Import,Export,Upload,Audit等，多个权限用逗号分隔")]
    [DataObjectField(false, false, true, 0)]
    [BindColumn("AuthValue", "存储具体的权限操作。如Search,Add,Delete,Update,Import,Export,Upload,Audit等，多个权限用逗号分隔", "text")]
    public String? AuthValue { get => _AuthValue; set { if (OnPropertyChanging("AuthValue", value)) { _AuthValue = value; OnPropertyChanged("AuthValue"); } } }

    private Int32 _SysMenuId;
    /// <summary>菜单编号</summary>
    [DisplayName("菜单编号")]
    [Description("菜单编号")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("SysMenuId", "菜单编号", "")]
    public Int32 SysMenuId { get => _SysMenuId; set { if (OnPropertyChanging("SysMenuId", value)) { _SysMenuId = value; OnPropertyChanged("SysMenuId"); } } }

    private Int32 _RoleId;
    /// <summary>角色编号</summary>
    [DisplayName("角色编号")]
    [Description("角色编号")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("RoleId", "角色编号", "")]
    public Int32 RoleId { get => _RoleId; set { if (OnPropertyChanging("RoleId", value)) { _RoleId = value; OnPropertyChanged("RoleId"); } } }

    private Int32 _UserId;
    /// <summary>用户编号</summary>
    [DisplayName("用户编号")]
    [Description("用户编号")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("UserId", "用户编号", "")]
    public Int32 UserId { get => _UserId; set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } } }

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
    public void Copy(ISysRoleAuth model)
    {
        Id = model.Id;
        AuthValue = model.AuthValue;
        SysMenuId = model.SysMenuId;
        RoleId = model.RoleId;
        UserId = model.UserId;
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
            "AuthValue" => _AuthValue,
            "SysMenuId" => _SysMenuId,
            "RoleId" => _RoleId,
            "UserId" => _UserId,
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
                case "AuthValue": _AuthValue = Convert.ToString(value); break;
                case "SysMenuId": _SysMenuId = value.ToInt(); break;
                case "RoleId": _RoleId = value.ToInt(); break;
                case "UserId": _UserId = value.ToInt(); break;
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
    public static SysRoleAuth? FindById(Int32 id)
    {
        if (id < 0) return null;

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Id == id);

        // 单对象缓存
        return Meta.SingleCache[id];

        //return Find(_.Id == id);
    }

    /// <summary>根据菜单编号、角色编号查找</summary>
    /// <param name="sysMenuId">菜单编号</param>
    /// <param name="roleId">角色编号</param>
    /// <returns>实体对象</returns>
    public static SysRoleAuth? FindBySysMenuIdAndRoleId(Int32 sysMenuId, Int32 roleId)
    {
        if (sysMenuId < 0) return null;
        if (roleId < 0) return null;

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.SysMenuId == sysMenuId && e.RoleId == roleId);

        return Find(_.SysMenuId == sysMenuId & _.RoleId == roleId);
    }

    /// <summary>根据菜单编号查找</summary>
    /// <param name="sysMenuId">菜单编号</param>
    /// <returns>实体列表</returns>
    public static IList<SysRoleAuth> FindAllBySysMenuId(Int32 sysMenuId)
    {
        if (sysMenuId < 0) return [];

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SysMenuId == sysMenuId);

        return FindAll(_.SysMenuId == sysMenuId);
    }

    /// <summary>根据菜单编号、角色编号、用户编号查找</summary>
    /// <param name="sysMenuId">菜单编号</param>
    /// <param name="roleId">角色编号</param>
    /// <param name="userId">用户编号</param>
    /// <returns>实体对象</returns>
    public static SysRoleAuth? FindBySysMenuIdAndRoleIdAndUserId(Int32 sysMenuId, Int32 roleId, Int32 userId)
    {
        if (sysMenuId < 0) return null;
        if (roleId < 0) return null;
        if (userId < 0) return null;

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.SysMenuId == sysMenuId && e.RoleId == roleId && e.UserId == userId);

        return Find(_.SysMenuId == sysMenuId & _.RoleId == roleId & _.UserId == userId);
    }

    /// <summary>根据菜单编号、角色编号查找</summary>
    /// <param name="sysMenuId">菜单编号</param>
    /// <param name="roleId">角色编号</param>
    /// <returns>实体列表</returns>
    public static IList<SysRoleAuth> FindAllBySysMenuIdAndRoleId(Int32 sysMenuId, Int32 roleId)
    {
        if (sysMenuId < 0) return [];
        if (roleId < 0) return [];

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SysMenuId == sysMenuId && e.RoleId == roleId);

        return FindAll(_.SysMenuId == sysMenuId & _.RoleId == roleId);
    }
    #endregion

    #region 字段名
    /// <summary>取得角色权限表字段信息的快捷方式</summary>
    public partial class _
    {
        /// <summary>编号</summary>
        public static readonly Field Id = FindByName("Id");

        /// <summary>存储具体的权限操作。如Search,Add,Delete,Update,Import,Export,Upload,Audit等，多个权限用逗号分隔</summary>
        public static readonly Field AuthValue = FindByName("AuthValue");

        /// <summary>菜单编号</summary>
        public static readonly Field SysMenuId = FindByName("SysMenuId");

        /// <summary>角色编号</summary>
        public static readonly Field RoleId = FindByName("RoleId");

        /// <summary>用户编号</summary>
        public static readonly Field UserId = FindByName("UserId");

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

    /// <summary>取得角色权限表字段名称的快捷方式</summary>
    public partial class __
    {
        /// <summary>编号</summary>
        public const String Id = "Id";

        /// <summary>存储具体的权限操作。如Search,Add,Delete,Update,Import,Export,Upload,Audit等，多个权限用逗号分隔</summary>
        public const String AuthValue = "AuthValue";

        /// <summary>菜单编号</summary>
        public const String SysMenuId = "SysMenuId";

        /// <summary>角色编号</summary>
        public const String RoleId = "RoleId";

        /// <summary>用户编号</summary>
        public const String UserId = "UserId";

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
