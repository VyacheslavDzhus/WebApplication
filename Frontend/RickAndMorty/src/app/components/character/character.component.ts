import { Component, OnInit } from '@angular/core';
import { Character } from 'src/app/models/character';
import { CharacterService } from 'src/app/services/character.service';

@Component({
  selector: 'app-character',
  templateUrl: './character.component.html',
  styleUrls: ['./character.component.css']
})
export class CharacterComponent implements OnInit {

  characters : Character[] = [];
  
  constructor(private characterService: CharacterService) { }

  ngOnInit(): void {
  }
  
  getAll(){
    this.characterService.getAll().subscribe((characters: Character[]) => {
      console.log(characters[0]);
      this.characters = characters;
    });
  }
}
