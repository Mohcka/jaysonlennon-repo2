import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-maintenance-man',
  templateUrl: './maintenance-man.component.html',
  styleUrls: ['./maintenance-man.component.css']
})
export class MaintenanceManComponent implements OnInit {
  headers = ["ID", "Date", "Apartment", "Request"]
  rows = [
      {
        "ID" : "1",
        "Date" : "04/28/20",
        "Apartment": "101",
        "Request" : "Request 1"
      },
      {
        "ID" : "2",
        "Date" : "04/30/20",
        "Apartment": "102",
        "Request" : "Request 2"
      },
      {
        "ID" : "3",
        "Date" : "05/01/20",
        "Apartment": "201",
        "Request" : "Request 3"
      },
      {
        "ID" : "4",
        "Date" : "05/05/20",
        "Apartment": "301",
        "Request" : "Request 4"
      },
      {
        "ID" : "5",
        "Date" : "05/15/20",
        "Apartment": "100",
        "Request" : "Request 5"
      },
    ]
  constructor() { }

  ngOnInit(): void {
  }

}
