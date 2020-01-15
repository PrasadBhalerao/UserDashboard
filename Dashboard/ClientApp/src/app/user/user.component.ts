import { Component, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { UserEditComponent } from './user-edit/user-edit.component';
import { UserService } from './user.service';
import { User } from './models';

@Component({
  selector: 'user-list',
  templateUrl: './user.component.html',
  providers: [MatDialog, UserService]
})
export class UserComponent {
  public users: User[];
  private _dialog: MatDialog;
  private _userService: UserService;
  public searchText: string;
  searchQueryUpdate = new Subject<string>();

  constructor(matDialog: MatDialog, userService: UserService) {
    this._dialog = matDialog;
    this._userService = userService;
    this.getUsers(null);
    this.searchText = "";

    this.searchQueryUpdate.pipe(
      debounceTime(500),
      distinctUntilChanged())
      .subscribe(value => {
        this.getUsers(value);
      });
  }

  getUsers(query: string): void {
    this._userService.getUsers(query).subscribe((successResponse) => {
      this.users = successResponse;
    }, (errorResponse) => {
        alert('Error fetching users!');
    });
  }

  editUserDetails(user: User): void {
    let dialogRef = this._dialog.open(UserEditComponent, {
      data: { userDetail: user },
      width: '320px',
      height: '500px'
    });

    dialogRef.afterClosed().subscribe(() => {
      this.getUsers(null);
    });
  }

  addUser() {
    this.editUserDetails(null);
  }

}
