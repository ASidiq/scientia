import { Component, OnInit, HostListener, } from '@angular/core';
import { SharedService } from '../shared.service';
import { Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-update-delete-book',
  templateUrl: './update-delete-book.component.html',
  styleUrls: ['./update-delete-book.component.css']
})
export class UpdateDeleteBookComponent implements OnInit {

  public state: any;
  currentYear: number = new Date().getFullYear();
  form: any;
  types: string[] = ["Fiction", "Non-Fiction"]
  genres: string[] = ["Action and adventure", "Alternate history", "Anthology", "Children's",
    "Classic", "Comic book", "Coming - of - age", "Crime", "Drama", "Fairytale", "Fantasy",
    "Graphic novel", "Historical fiction", "Horror", "Mystery", "Paranormal romance", "Picture book",
    "Poetry", "Political thriller", "Romance", "Satire", "Science fiction", "Short story",
    "Suspense", "Western thriller", "Young adult"];

  constructor(private fb: FormBuilder, private service: SharedService, private router: Router) { }

  // @HostListener('window:unload') goToPage() {
  //   this.router.navigate(['/catalogue']);
  // }

  ngOnInit(): void {
    //this.state = this.router.getCurrentNavigation.state
    this.state = window.history.state.data
    console.log(this.state);
    this.form = this.fb.group({
      "title": [this.state.title, Validators.required],//[first value = value of control, remaining values = control's validators]
      "bookCoverUrl": [this.state.cover, Validators.required],
      "bookType": [this.state.type, Validators.required],
      "bookGenre": [this.state.genre, Validators.required],
      "publisherCountry": [this.state.location, Validators.required],
      "yearPublished": [Number(this.state.date), [Validators.required, Validators.max(this.currentYear)]],
      "bookRating": [Number(this.state.rating), [Validators.required, Validators.min(1), Validators.max(10)]],
      "pageCount": [Number(this.state.pages), Validators.required],
      "bookCopies": [Number(this.state.copies), Validators.required]
    });
  }

  onDelete() {
    if (confirm(`You want to delete ${this.form.value.title}`)) {
      this.service.deleteBook(this.form.value.title).subscribe(data => {
        alert(`${this.form.value.title} deleted!`)
        this.router.navigate(['/catalogue']);
      })
    }
    else {
      console.log("retracted");
    }

  }

  async onUpdateBook() {

    await this.testImage(this.form.value.bookCoverUrl)
      .then(success => {
        console.log(success + ": book cover loaded");
        this.service.updateBook({
          title: this.form.value.title,
          publishedDate: this.form.value.yearPublished,
          type: this.form.value.bookType,
          genre: this.form.value.bookGenre,
          location: this.form.value.publisherCountry,
          totalPages: this.form.value.pageCount,
          rating: this.form.value.bookRating,
          copies: this.form.value.bookCopies,
          bookPictureUrl: this.form.value.bookCoverUrl
        }, Number(this.state.id)).subscribe(data => {
          alert("Book Updated!")
          this.router.navigate(['/catalogue']);
          console.log("Book Updated")
        })
      })
      .catch(error => {
        alert(error + ": New Book URL must point to an image")
      });
  }

  testImage(url) {
    return new Promise(function (resolve, reject) {
      var timeout = 5000;
      var timer, img = new Image();
      img.onerror = img.onabort = function () {
        clearTimeout(timer);
        reject("error");
      };
      img.onload = function () {
        clearTimeout(timer);
        resolve("success");
      };
      timer = setTimeout(function () {
        // reset .src to invalid URL so it stops previous
        // loading, but doesn't trigger new load
        img.src = "//!!!!/test.jpg";
        reject("timeout");
      }, timeout);
      img.src = url;
    });

  }


}
