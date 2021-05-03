import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl: string = 'https://localhost:5001/api';

  constructor(private http: HttpClient) { }

  //Books APIs
  getEntireCatalogue(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/books');
  }

  getBook(title: string): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + `/books/${title}`)
  }

  addBook(bookDetails: any) {
    return this.http.post(this.APIUrl + '/books', bookDetails);
  }

  updateBook(bookID: number) {
    return this.http.put(this.APIUrl + '/books', bookID);
  }

  deleteBook(title: string) {
    return this.http.delete(this.APIUrl + `/books/${title}`);
  }

  //Author APIs
  getAllAuthors(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/authors');
  }

  getAuthor(title: string): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + `/authors/${title}`)
  }

  updateAuthor(authorID: number) {
    return this.http.put(this.APIUrl + '/authors', authorID);
  }

  deleteAuthor(title: string) {
    return this.http.delete(this.APIUrl + `/authors/${title}`);
  }
}
