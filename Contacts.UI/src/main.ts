import { createApp } from 'vue'
import './style.css'
import App from './App.vue'

import router from './router/index'; //biblioteka do routingu.

createApp(App)
    .use(router) //routing poszczególnych komponentów.
    .mount('#app')
