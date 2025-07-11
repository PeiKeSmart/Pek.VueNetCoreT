using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Pek.Entity;

/// <summary>系统角色表</summary>
public partial class SysRoleModel
{
    #region 属性
    /// <summary>编号</summary>
    public Int32 Id { get; set; }

    /// <summary>菜单名称</summary>
    public String Name { get; set; } = null!;

    /// <summary>部门名称</summary>
    public String? DeptName { get; set; }

    /// <summary>部门编号</summary>
    public Int32 DeptId { get; set; }

    /// <summary>是否启用</summary>
    public Boolean Enable { get; set; }

    /// <summary>排序号</summary>
    public Int32 OrderNo { get; set; }

    /// <summary>父级角色ID</summary>
    public Int32 ParentId { get; set; }

    /// <summary>删除该角色的用户（软删除标记）</summary>
    public String? DeleteBy { get; set; }

    /// <summary>创建者</summary>
    public String? CreateUser { get; set; }

    /// <summary>创建者</summary>
    public Int32 CreateUserID { get; set; }

    /// <summary>创建时间</summary>
    public DateTime CreateTime { get; set; }

    /// <summary>创建地址</summary>
    public String? CreateIP { get; set; }

    /// <summary>更新者</summary>
    public String? UpdateUser { get; set; }

    /// <summary>更新者</summary>
    public Int32 UpdateUserID { get; set; }

    /// <summary>更新时间</summary>
    public DateTime UpdateTime { get; set; }

    /// <summary>更新地址</summary>
    public String? UpdateIP { get; set; }
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
}
