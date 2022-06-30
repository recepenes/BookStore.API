import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllboksComponent } from './allboks/allboks.component';

const routes: Routes = [
  {path:'books',component:AllboksComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
