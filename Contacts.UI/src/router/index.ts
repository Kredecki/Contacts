import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import { RouterNameEnum } from '../types/enums/RouterNameEnum';
import { RouterUrlEnum } from '../types/enums/RouterUrlEnum';

import Details from '../components/Contact-Details.vue'
import List from '../components/Contact-List.vue'
import SignUp from '../components/SignUp.vue'
import SignIn from '../components/SignIn.vue'
import Add from '../components/Add-Contact.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: RouterUrlEnum.Details,
    name: RouterNameEnum.Details,
    component: Details
  },
  {
    path: RouterUrlEnum.List,
    name: RouterNameEnum.List,
    component: List
  },
  {
    path: RouterUrlEnum.SignUp,
    name: RouterNameEnum.SignUp,
    component: SignUp
  },
  {
    path: RouterUrlEnum.SignIn,
    name: RouterNameEnum.SignIn,
    component: SignIn
  },
  {
    path: RouterUrlEnum.Add,
    name: RouterNameEnum.Add,
    component: Add
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;