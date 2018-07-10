export class Navigation {
  private _title: string;
  private _link: string;
  private _href: string;
  private _id: string;
  private _subItems: Navigation[];
  private _isParent: boolean;

  constructor() {
    this._subItems = new Array<Navigation>();
  }

  get title(): string {
    return this._title;
  }
  set title(value: string) {
    this._title = value;
  }

  get isParent(): boolean {
    return this._isParent;
  }
  set isParent(value: boolean) {
    this._isParent = value;
  }

  get subItems(): Navigation[] {
    return this._subItems;
  }
  set subItems(value: Navigation[]) {
    this._subItems = value;
  }

  get link(): string {
    return this._link;
  }
  set link(value: string) {
    this._link = value;
  }

  get href(): string {
    return this._href;
  }
  set href(value: string) {
    this._href = value;
  }

  get id(): string {
    return this._id;
  }
  set id(value: string) {
    this._id = value;
  }


}
