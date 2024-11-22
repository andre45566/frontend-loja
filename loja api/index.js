import Vue from "vue";
import Router from "vue-router";
import ListarUsuarios from "@/components/ListarUsuarios.vue"
import CadastrarUsuario from "@/components/CadastrarUsuario.vue"

Vue.use(Router);

export default new Router({
mode:"history",
routes: [
    {
        path:"/usuarios",
        name:"ListarUsuarios",
        component: ListarUsuarios
    },

    {
        path:"/usuarios/cadastrar",
        name:"CadastrarUsuario",
        component: CadastrarUsuario
    }
]
})