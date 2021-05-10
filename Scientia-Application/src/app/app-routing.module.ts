import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CatalogueComponent } from './catalogue/catalogue.component';
import { HomeComponent } from './home/home.component';
import { CreateBookComponent } from './create-book/create-book.component'
import { UpdateDeleteBookComponent } from './update-delete-book/update-delete-book.component'
import { UpdateDeleteAuthorComponent } from './update-delete-author/update-delete-author.component'
import { ViewAuthorComponent } from './view-author/view-author.component'
const routes: Routes = [
  { path: 'catalogue', component: CatalogueComponent, pathMatch: 'full' },
  { path: 'addbook', component: CreateBookComponent, pathMatch: 'full' },
  { path: 'update-delete-book', component: UpdateDeleteBookComponent, pathMatch: 'full' },
  { path: 'authors', component: ViewAuthorComponent, pathMatch: 'full' },
  { path: 'update-delete-author', component: UpdateDeleteAuthorComponent, pathMatch: 'full' },
  { path: '', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
