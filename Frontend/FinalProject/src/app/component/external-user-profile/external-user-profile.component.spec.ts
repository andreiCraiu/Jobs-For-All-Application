import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExternalUserProfileComponent } from './external-user-profile.component';

describe('ExternalUserProfileComponent', () => {
  let component: ExternalUserProfileComponent;
  let fixture: ComponentFixture<ExternalUserProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExternalUserProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExternalUserProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
