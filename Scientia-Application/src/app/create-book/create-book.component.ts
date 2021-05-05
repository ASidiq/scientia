import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { map, filter } from 'rxjs/operators';
import { SharedService } from '../shared.service'


@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css']
})
export class CreateBookComponent implements OnInit {
  constructor(private fb: FormBuilder, private service: SharedService) { }

  currentYear: number = new Date().getFullYear();
  noCover: string = 'https://ngmintlsubs.nationalgeographic.com/Solo/Content/Images/noCover.gif';
  types: string[] = ["Fiction", "Non-Fiction"]
  genres: string[] = ["Action and adventure", "Alternate history", "Anthology", "Children's",
    "Classic", "Comic book", "Coming - of - age", "Crime", "Drama", "Fairytale", "Fantasy",
    "Graphic novel", "Historical fiction", "Horror", "Mystery", "Paranormal romance", "Picture book",
    "Poetry", "Political thriller", "Romance", "Satire", "Science fiction", "Short story",
    "Suspense", "Western thriller", "Young adult"]


  ngOnInit(): void {

  }

  form = this.fb.group({
    "title": ["", Validators.required],//[first value = value of control, remaining values = control's validators]
    "authorName": ["", Validators.required],
    "bookCoverUrl": [this.noCover, Validators.required],
    "authorImageUrl": [this.noCover, Validators.required],
    "bookType": ["", Validators.required],
    "bookGenre": ["", Validators.required],
    "publisherCountry": ["", Validators.required],
    "yearPublished": ["", [Validators.required, Validators.max(this.currentYear)]],
    "bookRating": ["", [Validators.required, Validators.min(1), Validators.max(10)]],
    "pageCount": ["", Validators.required],
    "bookCopies": ["", Validators.required]
  });



  async onSubmitAddBook() {
    await this.testImage(this.form.value.bookCoverUrl)
      .then(success => {
        console.log(success + ": book cover loaded");
        return "success";
      })
      .then(success => {
        this.testImage(this.form.value.authorImageUrl)
          .then(success => {
            console.log(success + ": author cover loaded");
            this.service.addBook({
              title: this.form.value.title,
              publishedDate: this.form.value.yearPublished,
              type: this.form.value.bookType,
              genre: this.form.value.bookGenre,
              location: this.form.value.publisherCountry,
              totalPages: this.form.value.pageCount,
              rating: this.form.value.bookRating,
              copies: this.form.value.bookCopies,
              bookPictureUrl: this.form.value.bookCoverUrl,
              authorName: this.form.value.authorName,
              authorPicUrl: this.form.value.authorImageUrl
            }).subscribe(data => {
              alert("Book Added!")
              console.log("Book Added")
            })
          })
          .catch(error => {
            alert(error + ": Author URL must point to an image")
          })
      })
      .catch(error => {
        alert(error + ": Book URL must point to an image")
      })

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
