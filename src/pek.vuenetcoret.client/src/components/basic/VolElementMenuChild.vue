<template>
  <div class="vol-el-menu-item">
    <template v-for="(item) in list">
      
      <template v-if="item.children&&item.children.length">
        <el-menu-item :key="item.Id"
                      :index="'' + item.Id"
                      v-if="!item.children.length">
          <template #title></template>
          <span> {{ item.Name }}</span>
        </el-menu-item>
        <el-sub-menu :key="item.Id"
                    :index="'' + item.Id"
                    v-if="item.children.length">
          <template #title>
            <span> {{ item.Name }}</span>
          </template>
          <vol-element-menu-child :enable="enable" :list="item.children" />
        </el-sub-menu>
      </template>
      <template v-else>
        <el-menu-item :key="item.Id"
                      :index="'' + item.Id"
                      >
          <template #title></template>
          <span> {{item.Name }}</span>
        </el-menu-item>
      </template>
    </template>
  </div>
</template>

<script>
export default {
  name: "vol-element-menu-child",
  props: {
    list: {
      type: Array,
      default: [],
    },
    enable: {
      type: Boolean,
      default: false, //是否判断enable=1
    },
  },
  setup(props) {
    console.log('props', props)
  }
};
</script>

<style scoped lang="less">
.vol-el-menu-item ::v-deep(.el-menu-item) {
  height: 42px !important;
  line-height: 42px !important;
}
</style>



