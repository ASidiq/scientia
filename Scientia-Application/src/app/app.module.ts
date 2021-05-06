import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CatalogueComponent } from './catalogue/catalogue.component';
import { SharedService } from './shared.service';
import { CreateBookComponent } from './create-book/create-book.component';
import { UpdateDeleteBookComponent } from './update-delete-book/update-delete-book.component';
import { ViewAuthorComponent } from './view-author/view-author.component';
import { UpdateDeleteAuthorComponent } from './update-delete-author/update-delete-author.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CatalogueComponent,
    CreateBookComponent,
    UpdateDeleteBookComponent,
    ViewAuthorComponent,
    UpdateDeleteAuthorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MDBBootstrapModule.forRoot(),
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
