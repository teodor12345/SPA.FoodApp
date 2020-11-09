import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
    { path:'', redirectTo:'/home', pathMatch:'full' },
    { path:'home', component: HomeComponent },
    { path:'admin-panel', component: AdminPanelComponent }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }