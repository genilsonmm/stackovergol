import { createRouter, createWebHistory } from "vue-router";

import LoginView from "@/views/LoginView.vue";
import PlayerView from "@/views/PlayerView.vue";

import AppSiteView from "@/views/site/AppSiteView.vue";
import DashboardSiteView from "@/views/site/DashboardSiteView.vue";
import PanelView from "@/views/PanelView.vue";
import DashboardView from "@/views/DashboardView.vue";
import EventView from "@/views/EventView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/panel",
      name: "panel",
      component: PanelView,
      children: [
        {
          path: "/panel",
          name: "dashboard",
          component: DashboardView
        },
        {
          path: "/players",
          name: "players",
          component: PlayerView,
        },
        {
          path: "/events",
          name: "events",
          component: EventView,
        }
      ],
    },
    {
      path: "/",
      name: "home-site",
      component: AppSiteView,
      children: [
        {
          path: "/",
          name: "dashboad-site",
          component: DashboardSiteView
        }
      ]
    },
    {
      path: "/sign-in",
      name: "login",
      component: LoginView
    }
  ],
});

export default router;
