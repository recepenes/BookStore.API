import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';

@Component({
  selector: 'app-allboks',
  templateUrl: './allboks.component.html',
  styleUrls: ['./allboks.component.scss']
})
export class AllboksComponent implements OnInit {

  public books:any;
  constructor(private service:BookService) { }

  ngOnInit(): void {
    this.getBooks();
  }

private getBooks():void{
this.service.getBooks().subscribe(result =>{
this.books=result;
    } );
  }
}
