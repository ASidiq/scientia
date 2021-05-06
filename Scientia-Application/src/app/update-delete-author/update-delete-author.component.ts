import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-update-delete-author',
  templateUrl: './update-delete-author.component.html',
  styleUrls: ['./update-delete-author.component.css']
})
export class UpdateDeleteAuthorComponent implements OnInit {

  public state: any;
  form: any;

  constructor(private fb: FormBuilder, private service: SharedService, private router: Router) { }

  // @HostListener('window:unload') goToPage() {
  //   this.router.navigate(['/catalogue']);
  // }

  ngOnInit(): void {
    //this.state = this.router.getCurrentNavigation.state
    this.state = window.history.state.data
    console.log(this.state);
    this.form = this.fb.group({
      "name": [this.state.author, Validators.required],//[first value = value of control, remaining values = control's validators]
      "authorProfilePicUrl": [this.state.photo, Validators.required]
    });
  }

  onDeleteAuthor() {
    if (confirm(`You want to delete ${this.form.value.name}'s Profile?`)) {
      this.service.deleteAuthor(this.form.value.name).subscribe(data => {
        alert(`${this.form.value.name} deleted!`)
        this.router.navigate(['/authors']);

      })
    }
    else {
      console.log("retracted");
    }

  }

  async onUpdateProfile() {

    await this.testImage(this.form.value.authorProfilePicUrl)
      .then(success => {
        console.log(success + ": author's profile picture loaded");
        this.service.updateAuthor({
          Name: this.form.value.name,
          authorPicUrl: this.form.value.authorProfilePicUrl
        }, Number(this.state.id)).subscribe(data => {
          alert("Author's Profile Updated!")
          this.router.navigate(['/authors']);
          console.log("Author's Profile Updated")
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
