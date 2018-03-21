import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//component
import { AppComponent } from './app.component';
// import { AddNewComponent } from './add-new/add-new.component';
import { ProductsHomeComponent } from './products-home/products-home.component';
import { EditComponent } from './edit/edit.component';
import { ShowComponent } from './show/show.component';
import { NewrestaurantComponent } from './newrestaurant/newrestaurant.component';
import { RewiewComponent  } from './rewiew/rewiew.component';
import { AddNewComponent } from './add-new/add-new.component';
const routes: Routes = [
  { path: 'new', component: NewrestaurantComponent},
  { path: '', component: ProductsHomeComponent},
  { path: 'edit/:id', component: EditComponent},
  { path: 'show/:id', component: ShowComponent},
  { path: 'reviews/:id', component: RewiewComponent},
  { path: 'write/:id', component: AddNewComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
