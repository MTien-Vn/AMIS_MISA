<template>
  <div id="app">
    <TheNavar/>
    <TheHeader/>
    <TheContent/>
  </div>
</template>

<script>
import TheContent from './components/TheComponent/TheContent.vue'
import TheHeader from './components/TheComponent/TheHeader.vue'
import TheNavar from './components/TheComponent/TheNavar.vue'
export default {
  components: { 
    TheContent,
    TheNavar,
    TheHeader 
  },
  
}
</script>

<style>
@import './style/index.css';
#app {
  margin: 0;
  font-family: notosans-Regular;
  font-size: 13px;
}
</style>
