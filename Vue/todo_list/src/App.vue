<template>
  <img alt="Vue logo" src="./assets/logo.png" />
  <!-- <HelloWorld msg="Hello Vue 3 + TypeScript + Vite" /> -->
  <ToDoList />
</template>

<script lang="ts">
import { defineComponent } from "vue";
import HelloWorld from "./components/HelloWorld.vue";
import ToDoList from "./components/TodoList.vue";

export default defineComponent({
  name: "App",
  components: {
    HelloWorld,
    ToDoList,
  },
});
</script>
