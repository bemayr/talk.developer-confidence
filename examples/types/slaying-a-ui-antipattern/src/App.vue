<template>
  <div id="app">
    <h1>Correlation between field of study and IQ</h1>
    <Correlation/>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import Correlation from "./components/Correlation.vue";

@Component({
  components: {
    Correlation
  }
})
export default class App extends Vue {}
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
