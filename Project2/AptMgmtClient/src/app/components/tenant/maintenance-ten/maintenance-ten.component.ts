import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-maintenance-ten',
  templateUrl: './maintenance-ten.component.html',
  styleUrls: ['./maintenance-ten.component.css']
})
export class MaintenanceTenComponent implements OnInit {
  headers = ["ID", "Date", "Request"]
  rows = [
      {
        "ID" : "1",
        "Date" : "01/01/20",
        "Request" : "Request 1"
      },
      {
        "ID" : "2",
        "Date" : "02/02/20",
        "Request" : "Request 2"
      },
      {
        "ID" : "3",
        "Date" : "03/03/20",
        "Request" : "Request 3"
      },
      {
        "ID" : "4",
        "Date" : "04/04/20",
        "Request" : "Request 4"
      },
      {
        "ID" : "5",
        "Date" : "05/05/20",
        "Request" : "Request 5"
      },
    ]
  constructor() { }

  ngOnInit(): void {
  }

}
