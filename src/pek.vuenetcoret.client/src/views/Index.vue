<template>
  <div>
    123
  </div>
</template>
<script>
import {
  defineComponent,
  // reactive,
  // ref,
  // watch,
  // onMounted,
  // getCurrentInstance,
} from "vue";
// import { useRouter, useRoute } from "vue-router";
// import store from "../store/index";
import http from "@/../src/api/http.js";
export default defineComponent({
  data() {
    return {
      allTabs: true,
      leftTabs: true,
      rightTabs: true,
      otherTabs: true,
      menuLeft: 0,
      menuTop: 0,
      //  contextMenuVisible: false, // 右键关闭显/隐
    };
  },
  setup(props, context) {
    const created = () => {

      console.log('进来')
      http.post("api/v1/menu/getTreeMenu", {}, true).then((data) => {

      });
    };
    created();
    return {
      // menuWidth,
      // isCollapse,
      // drawer_model,
      // theme_color,
      // errorImg,
      // userInfo,
      // userName,
      // userImg,
      // selectId,
      // selectMenuIndex,
      // navigation,
      // links,
      // onSelect,
      // openTabsMenu,
      // selectNav,
      // getSelectMenuName,
      // removeNav,
      // logo,
      // theme,
      // menuOptions,
      // permissionInited,
      // changeTheme,
      // to,
      // toggleLeft,
      // messageModel,
      // messageList,
      // contextMenuVisible,
      // visibleItem,
      // closeTabsMenu,
      // closeTabs,
      // currentMenuId,
    };
  },
  /**
   * 挂载钩子函数
   */
  // mounted() {
  //   let _date = showTime();
  //   $indexDate = document.getElementById("index-date");
  //   $indexDate.innerText = _date;
  //   $interval = setInterval(function () {
  //     $indexDate.innerText = showTime();
  //   }, 1000);

  //   this.bindRightClickMenu(true);
  // },

  // methods: {
  //   /**
  //    * 绑定右键事件
  //    * @param {*} enable 是否启用右键事件[true:启用;false:禁用;]
  //    * @param {*} $event 事件
  //    */
  //   bindRightClickMenu(enable) {
  //     if (!enable) return;
  //     let that = this;
  //     // 使用原生js 为单个dom绑定鼠标右击事件
  //     that.$nextTick(() => {
  //       let tab_top_dom = Object.assign(
  //         [],
  //         document.getElementsByClassName("el-tabs__item is-top")
  //       );
  //       tab_top_dom.forEach((item, index) => {
  //         item.oncontextmenu = that.openTabsMenu;
  //       });
  //     });
  //   },
  // },

  // /**
  //  * 销毁钩子函数
  //  */
  // destroyed() {
  //   $this = null;
  //   clearInterval($interval);
  // },
});
// const week = new Array(
//   "星期一",
//   "星期二",
//   "星期三",
//   "星期四",
//   "星期五",
//   "星期六",
//   "星期日"
// );
// function showTime() {
//   let date = new Date();
//   let year = date.getFullYear();
//   let month = date.getMonth() + 1;
//   let day = date.getDate();
//   let hour = date.getHours();
//   let minutes = date.getMinutes();
//   let second = date.getSeconds();

//   return (
//     year +
//     "." +
//     (month < 10 ? "0" + month : month) +
//     "." +
//     (day < 10 ? "0" + day : day) + //202.08.08修复日期天数小于10时添加0
//     "" +
//     " " +
//     (hour < 10 ? "0" + hour : hour) +
//     ":" +
//     (minutes < 10 ? "0" + minutes : minutes) +
//     ":" +
//     (second < 10 ? "0" + second : second) +
//     " " + //2020.08.30修复首页日期星期天不显示的问题
//     (week[date.getDay() - 1] || week[6])
//   );
// }
</script>

<style lang="less" scoped>
.vol-container .vol-path ::v-deep(.el-tabs__content) {
  padding: 0;
}

.contextMenu {
  width: 120px;
  margin: 0;
  border: 1px solid #eaeaea;
  background: #fff;
  z-index: 30000;
  position: absolute;
  list-style-type: none;
  padding: 5px 0;
  border-radius: 4px;
  font-size: 14px;
  color: #333;
  box-shadow: 2px 2px 3px 0 rgb(182 182 182 / 20%);
  i,button{
    font-size: 14px !important;
  }
}

.contextMenu li {
  margin: 0;
  padding: 5px 17px;
}

.contextMenu li:hover {
  background: #fafafa;
  cursor: pointer;
}

.contextMenu li button {
  color: #626060;
  font-size: 14px;
  letter-spacing: 1px;
}

.el-tabs.el-tabs--top.el-tabs--border-card.header-navigation
  > .el-tabs__header
  .el-tabs__item:last-child,
.el-tabs--top.el-tabs--border-card.header-navigation
  > .el-tabs__header
  .el-tabs__item:nth-child(2) {
  padding: 0;
}

.header-navigation ::v-deep(.el-tabs__item.is-top) {
  padding: 0 15px;
}
</style>
<style>
.horizontal-collapse-transition {
  transition: 0s width ease-in-out, 0s padding-left ease-in-out,
    0s padding-right ease-in-out;
}
</style>
