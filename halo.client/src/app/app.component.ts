import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit{
  title = 'app';
  apiValues: string[] = [];

  constructor(private _http: Http) { }

  ngOnInit(): void {
    this._http.get("/api/values")
          .subscribe(resp => this.apiValues = resp.json() as string[])
  }
}
