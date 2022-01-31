using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModernFamilyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModernFamilyController : ControllerBase
    {

        private static List<ModernFamily> characters = new List<ModernFamily> {
                new ModernFamily {
                    Id="1",
                    Name ="Mitchel",
                    LastName="Pritchet",
                    SpecialFeature="He is orange"

                },
                new ModernFamily {
                    Id="2",
                    Name ="Phill",
                    LastName="Dunphy",
                    SpecialFeature="Wizard of all time"

                },
                new ModernFamily {
                    Id="3",
                    Name ="Cameron",
                    LastName="Tucker",
                    SpecialFeature="He grown the biggest pumpkin"

                }
            };

        [HttpGet("getcharacter")]
        public IActionResult Get()
        {


            return Ok(characters); //status code 200

        }


        [HttpPost("addcharacter")]

        public async Task<ActionResult<List<ModernFamily>>> Add([FromBody] ModernFamily mf)
        {

            characters.Add(mf);
            return Ok(characters);
        }

        [HttpGet("getsingle/{id}")]
        public async Task<ActionResult<ModernFamily>> Get(string id)
        {
            var character = characters.Find(x => x.Id == id);
            if (character == null)
            {
                return BadRequest("Character is not found");
            }
            return Ok(character); //status code 200

        }

        [HttpPut("updatecharacter/{id}")]
        public async Task<ActionResult<ModernFamily>> UpdateCharacter([FromBody] ModernFamily mf)
        {
            var character = characters.Find(x => x.Id == mf.Id);
            if (character == null)
            {
                return BadRequest("Character is not found");
            }
            
            character.Name= mf.Name;
            character.LastName=mf.LastName;
            character.SpecialFeature=mf.SpecialFeature;


            return Ok(character); //status code 200

        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<List<ModernFamily>>> Delete(string id)
        {
            var character = characters.Find(x => x.Id == id);
            if (character == null)
            {
                return BadRequest("Character is not found");
            }
            characters.Remove(character);

            return Ok(characters); //status code 200

        }

    }

   
}
