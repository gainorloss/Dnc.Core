# Vue v-model原理及示例

1. GInput.vue
重点在于单向数据流的*prop:value*实现上向下传递，*this.$emit('input',[this.inputValue])*下向上传递
``` javascript
<template>
  <div>
    <input type="text" :value='inputValue' @input='inputHandler'>
  </div>
</template>

<script>
export default {
    props: {
        value: {
            type: String,
            default:''
        },
    },
    data() {
        return {
            inputValue: this.value
        }
    },
    methods: {
        inputHandler(e) {
            this.inputValue=e.target.value;
            this.$emit('input',this.inputValue);
        }
    }
};
</script>

<style lang="css" scoped>
</style>
```

2. 使用

``` javascript
<template>
  <div id="app">
    <div>
     <g-input v-model="inputValue"></g-input>
    </div>
  </div>
</template>

<script>
import GInput from "./components/GInput.vue";

export default {
  data() {
    return {
      inputValue: "someValue"
    };
  },
  components: {
    GInput
  }
};
</script>

<style>
</style>

```