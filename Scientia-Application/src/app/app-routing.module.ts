import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CatalogueComponent } from './catalogue/catalogue.component';
import { CreateBookComponent } from './create-book/create-book.component'
import { UpdateDeleteBookComponent } from './update-delete-book/update-delete-book.component'
const routes: Routes = [
  { path: 'catalogue', component: CatalogueComponent, pathMatch: 'full' },
  { path: 'addbook', component: CreateBookComponent, pathMatch: 'full' },
  { path: 'update-delete-book', component: UpdateDeleteBookComponent, pathMatch: 'full' }
  //{path:'authors', component: AuthorComponent, pathMatch: 'full' }
  //{path:'author-update-delete', component}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
