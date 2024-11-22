<template>
    <div class="listar-usuarios">
        <h1 class="text-center">Listagem de Usuários</h1>
        <table id="usuarios" clas="table table-striped table-boredered">
            <thead class="thead-dark">
                <tr>
                    <th>Id</th>
                    <th>Nome</th>
                    <th>E-mail</th>
                    <th>Endereço</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="usuario in usuarios" :key="usuario.id">
                    <td>{{ usuario.id }}</td>
                    <td>{{ usuario.nome}}</td>
                    <td>{{ usuario.email }}</td>
                    <td>{{ usuario.endereco }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<script>
import  axios from 'axios'

export default ({
    name: "ListarUsuarios",
    data(){
     return{
        usuarios:[]
     };
    },
    methods:{
       async ListarUsuarios (){
        try{
            const response = await axios.get("https://localhost:7040/api/usuario/listar-usuarios");
            this.usuarios = response.data
        }catch(error){
            console.error("deu merda aí zé");
        }
       },
    },
    created(){
        this.ListarUsuarios();
    }
})
</script>

<style scoped>
.listar-usuarios {
  margin: 20px;
}
table {
  width: 100%;
  border-collapse: collapse;
}
th,td {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: left;
}
th{
  background-color: #f4f4f4;
  font-weight: bold
}
</style>