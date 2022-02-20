import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  public itemActive = false;
  public indexSelected = null;
  public icons = [
    'home', 'search', 'work', 'settings', 'email'
  ]
  constructor() { }
  
  ngOnInit(): void {
  }

  activeItem(test: any, index: any){
      this.itemActive = true;
      this.indexSelected = index
      console.log('is',this.indexSelected)
  }

}
