import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import axios from 'axios';
import VueAxios from 'vue-axios';



//配置请求根路径
axios.defaults.baseURL="http://47.118.78.110:80"
Vue.prototype.$axios = axios;

axios.defaults.headers.post['Content-Type'] = 'application/json';



Vue.config.productionTip = false

//+引入组件库及相关样式
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import vuetify from './plugins/vuetify'

import VueSweetalert2 from 'vue-sweetalert2';
import VueParticles from 'vue-particles'
import 'sweetalert2/dist/sweetalert2.min.css';

//让Vue使用ElementUI
Vue.use(ElementUI)
Vue.config.productionTip = false
Vue.use(VueAxios, axios);
Vue.use(VueParticles)
        Vue.use(VueSweetalert2);

router.beforeEach((to,from,next)=>{
  if(to.meta.title){
    document.title=to.meta.title
  }
  next()
})

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
