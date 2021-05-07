import {ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild, ViewChildren} from '@angular/core';
import {ConfigurationService} from "../services/configuration.service";
import {Configuration} from "../models/parts.models";
import {Observable} from "rxjs";
import {AuthenticationService} from "../services/authentication.service";
import {Comment} from "../models/comment.model";
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-view-configurations',
  templateUrl: './view-configurations.component.html',
  styleUrls: ['./view-configurations.component.css']
})
export class ViewConfigurationsComponent implements OnInit, OnDestroy {
  public configurations: Configuration[];
  public commentsLoaded: boolean = false;

  @ViewChild(MatPaginator,{static: false}) paginator: MatPaginator;
  obs: Observable<Configuration[]>;
  dataSource: MatTableDataSource<Configuration>;

  constructor(private configurationService: ConfigurationService,
              private authService: AuthenticationService,
              private changeDetectorRef: ChangeDetectorRef) {

    this.configurationService.getAllConfigurations().subscribe( data =>{
      this.configurations = data;
    }, error1 => {},
      () => {
        this.setComments();
        this.setPagination();
      })
  }

  ngOnInit() {

  }

  toggleComments(id: number){
    if(document.getElementById("com-"+id).style.display == 'none')
    {
      document.getElementById("com-"+id).style.display = 'block'
    }
    else{
      document.getElementById("com-"+id).style.display = 'none'
    }
}

  addComment(conf: Configuration){
    let com: Comment = {text: (<HTMLInputElement>document.getElementById("in-"+conf.id)).value,
                        createdOn: Date.now(),
                        createdBy: this.authService.currentUserValue};
    console.log(typeof(com) + " a " + typeof(conf) );

    const body = {
      configuration_id: conf,
      comment_id: com,
    };


    this.configurationService.saveCommentForConfigurationId(body).subscribe(
      s=>{
        conf.comments.push(s);
      }
    )
  }

  setComments(){
    for(let c of this.configurations)
    {
      this.configurationService.getCommentsForConfigurationId(c.id).subscribe( x=> {
          c.comments = x;
        }, error1 => {}, ()=>{ this.commentsLoaded = true}
      );
    }
  }

  setPagination(){
    this.changeDetectorRef.detectChanges();
    this.dataSource = new MatTableDataSource<Configuration>(this.configurations);
    this.dataSource.paginator = this.paginator;
    this.obs = this.dataSource.connect();
  }
  ngOnDestroy() {
    if(this.dataSource){
      this.dataSource.disconnect();
    }
  }

}
