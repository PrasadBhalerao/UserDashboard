import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
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

  constructor(matDialog: MatDialog, userService: UserService) {
    this._dialog = matDialog;
    this._userService = userService;
    this.getUsers();


  }

  getUsers(): void {
    this._userService.getUsers().subscribe((successResponse) => {
      this.users = successResponse;
    }, (errorResponse) => {
        alert('Error fetching users!');
    });
  }

  editUserDetails(user: User): void {
    let dialogRef = this._dialog.open(UserEditComponent, {
      data: { userDetail: user }
    });


  }
}
