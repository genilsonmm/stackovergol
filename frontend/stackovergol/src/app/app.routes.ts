import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'match',
    pathMatch: 'full',
  },
  {
    path: 'match',
    loadComponent: () => import('./pages/match/match.page').then( m => m.MatchPage)
  },
  {
    path: 'statictics',
    loadComponent: () => import('./pages/statictics/statictics.page').then( m => m.StaticticsPage)
  },
];
