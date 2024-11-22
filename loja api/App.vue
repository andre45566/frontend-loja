<template>
  <div id="app">
    <nav class="navbar navbar-default">
      <div class="container-fluid">
        <div class="navbar-header">
          <a class="navbar-brand">LojaAPI</a>
        </div>
        <ul class="nav navbar-nav">
          <li>
      <router-link to="/usuarios">Listar Usuários</router-link>
    </li>
      <li>
      <router-link to="/usuarios/cadastrar">
        Cadastrar Usuarios</router-link>
      </li>
      </ul>
     </div>
    </nav>
    <router-view></router-view>
  </div>  
</template>

<script>
export default {
  name: 'App',
}
</script>

<style scoped>
</style>
