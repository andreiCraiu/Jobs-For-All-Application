import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  public itemActive = false;
  // forced to be 4. Default null
  public indexSelected = 4 ;
  public icons = [
    'home', 'supervised_user_circle', 'work', 'settings', 'email'
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
