<template>
    <div class="container cadastrar-usuario">
        <h1 class="text-center">Cadastrar Usuario</h1>
        
        <form @submit.prevent="cadastrarUsuario" class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">Nome:</label>
                <div class="col-sm-10">
                <input type="text" id="nome" 
                class="form-control"
                v-model="usuario.nome" required/>
            </div>
            </div>

            <div class="form-group">
                <label class="col-sm-2 control-label">Email:</label>
                <div class="col-sm-10">
                <input type="text" id="email"
                class="form-control" 
                v-model="usuario.email" required/>
            </div>
            </div>

            <div class="form-group">
                <label class="col-sm-2 control-label">Endereco:</label>
                <div class="col-sm-10">
                <input type="text" id="endereco"
                  class="form-control"
                 v-model="usuario.endereco" required/>
            </div>
            </div>

            <button type="submit">Salvar</button>
        </form>
    </div>
</template>
<script>
import axios  from 'axios'
export default ({
    name: "CadastrarUsuario",
    data(){
        return {
            usuario: {
                nome:"",
                email: "",
                endereco:""
            }
        };
    },
    methods:{
        async cadastrarUsuario(){
            try{
                await axios.post("https://localhost:7114/api/usuario/cadastrar-usuario", this.usuario);
                alert("Usuário cadastrado com sucesso");
                this.$router.push("/usuarios");
            }catch(error){
                console.error("Ocorreu um erro ao cadastrar o usuario");
            }
        },
    },
})
</script>

<style scoped>

</style>