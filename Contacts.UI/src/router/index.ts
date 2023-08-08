import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import { RouterNameEnum, RouterUrlEnum } from '../types/enums';

const routes: Array<RouteRecordRaw> = [];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;