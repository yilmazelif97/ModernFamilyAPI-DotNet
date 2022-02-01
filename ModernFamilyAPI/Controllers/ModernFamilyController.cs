using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModernFamilyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModernFamilyController : ControllerBase
    {
        private readonly Datacontext _db;

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
       
        public ModernFamilyController(Datacontext db)
        {
            _db=db;
        }

        [HttpGet("getcharacter")]
        public async Task<ActionResult<List<ModernFamily>>> Get()
        {


            return Ok(await _db.ModernFamilies.ToListAsync()); //status code 200

        }


        [HttpPost("addcharacter")]

        public async Task<ActionResult<List<ModernFamily>>> Add([FromBody] ModernFamily mf)
        {
            _db.ModernFamilies.Add(mf);
            await _db.SaveChangesAsync();
            //characters.Add(mf);
            return Ok(await _db.ModernFamilies.ToListAsync());
        }

        [HttpGet("getsingle/{id}")]
        public async Task<ActionResult<ModernFamily>> Get(string id)
        {
            var character = await _db.ModernFamilies.FindAsync(id);
            if (character == null)
            {
                return BadRequest("Character is not found");
            }
            return Ok(character); //status code 200

        }

        [HttpPut("updatecharacter/{id}")]
        public async Task<ActionResult<ModernFamily>> UpdateCharacter([FromBody] ModernFamily mf)
        {
            var character = await _db.ModernFamilies.FindAsync(mf.Id);
            if (character == null)
            {
                return BadRequest("Character is not found");
            }
            
            character.Name= mf.Name;
            character.LastName=mf.LastName;
            character.SpecialFeature=mf.SpecialFeature;

            await _db.SaveChangesAsync();

            return Ok(await _db.ModernFamilies.ToListAsync()); //status code 200

        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<List<ModernFamily>>> Delete(string id)
        {
            var character = await _db.ModernFamilies.FindAsync(id);
            if (character == null)
            {
                return BadRequest("Character is not found");
            }
            _db.ModernFamilies.Remove(character);
            await _db.SaveChangesAsync();

            return Ok(_db.ModernFamilies.ToListAsync()); //status code 200

        }

    }

   
}
