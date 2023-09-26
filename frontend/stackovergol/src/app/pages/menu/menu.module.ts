import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';


import { MenuPage } from './menu.page';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'menu',
    component: MenuPage,
    children: [
      {
        path: 'home',
        loadChildren: () =>  import('../home/home.module').then(m => m.HomePageModule)
      },
      {
        path: 'players',
        loadChildren: () => import('../players/players.module').then(m => m.PlayersPageModule)
      }
    ]
  },
  {
    path:'',
    redirectTo: '/menu/home',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [MenuPage]
})
export class MenuPageModule {}
