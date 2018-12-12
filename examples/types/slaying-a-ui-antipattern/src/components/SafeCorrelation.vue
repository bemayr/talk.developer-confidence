<template>
  <div class="hello">
    <table>
      <thead>
        <td>Studiengang</td>
        <td>Durchschnitts-IQ</td>
      </thead>
      <tr>
        <td>
          <input type="text">
        </td>
        <td>
          <input type="number">
        </td>
      </tr>
      <tr>
        <td>
          <input type="text">
        </td>
        <td>
          <input type="number">
        </td>
      </tr>
      <tr>
        <td>
          <input type="text">
        </td>
        <td>
          <input type="number">
        </td>
      </tr>
    </table>
    <button v-on:click="refresh()">Calculate Correlation</button>
    <div class="loading" v-if="isLoading">Loading...</div>
    <h3>
      <span>Correlation:&nbsp;</span>
      <span v-if="correlation.state === 'not-loaded'">...</span>
      <span v-if="correlation.state === 'loading'" class="loading">loading</span>
      <span v-if="correlation.state === 'success'">{{ correlation.data }}</span>
      <span v-if="correlation.state === 'error'" class="error">{{ correlation.message }}</span>
    </h3>
    <div class="error" v-if="hasError">Error: {{ errorMessage }}</div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { calculateCorrelation, RemoteData, withRemoteHandling } from "../api";

@Component
export default class SafeCorrelation extends Vue {
  correlation: RemoteData<number> = { state: "not-loaded" };

  async refresh(): Promise<void> {
    this.correlation = { state: "loading" };
    this.correlation = await withRemoteHandling(() => calculateCorrelation());
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.error {
  color: red;
}
.loading {
  color: darkblue;
}
table {
  margin: 0 auto;
}
</style>
