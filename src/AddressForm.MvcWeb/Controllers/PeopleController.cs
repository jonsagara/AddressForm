using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AddressForm.MvcWeb.Models;
using AutoMapper;

namespace AddressForm.MvcWeb.Controllers
{
    public class PeopleController : AddressFormBaseController
    {
        public async Task<ActionResult> New()
        {
            // Default to California, USA
            var model = new PersonEditorModel
            {
                RegionDropDownList = "CA",
                Country = "US"
            };

            model.Countries.AddRange(Mapper.Map<List<SelectListItem>>(await Context.Countries.OrderBy(c => c.Name).ToListAsync()));
            model.RegionsByCountry = (await Context.Regions.ToListAsync())
                .GroupBy(kvp => kvp.CountryId)
                .ToDictionary(grp => grp.Key, grp => grp.OrderBy(r => r.Name).Select(r => new SelectListItem { Text = r.Name, Value = r.Abbreviation }).ToList());
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(PersonEditorModel model)
        {
            if (ModelState.IsValid)
            {
                var person = Mapper.Map<PersonEditorModel, Person>(model);
                person.Id = Guid.NewGuid();

                Context.People.Add(person);
                await Context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            model.Countries.AddRange(Mapper.Map<List<SelectListItem>>(await Context.Countries.OrderBy(c => c.Name).ToListAsync()));
            model.RegionsByCountry = (await Context.Regions.ToListAsync())
                .GroupBy(kvp => kvp.CountryId)
                .ToDictionary(grp => grp.Key, grp => grp.OrderBy(r => r.Name).Select(r => new SelectListItem { Text = r.Name, Value = r.Abbreviation }).ToList());

            return View(model);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var person = GetPerson(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<Person, PersonEditorModel>(person);
            model.Countries.AddRange(Mapper.Map<List<SelectListItem>>(await Context.Countries.OrderBy(c => c.Name).ToListAsync()));
            model.RegionsByCountry = (await Context.Regions.ToListAsync())
                .GroupBy(kvp => kvp.CountryId)
                .ToDictionary(grp => grp.Key, grp => grp.OrderBy(r => r.Name).Select(r => new SelectListItem { Text = r.Name, Value = r.Abbreviation }).ToList());

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PersonEditorModel model)
        {
            if (ModelState.IsValid)
            {
                var person = GetPerson(model.Id);
                if (person == null)
                {
                    return HttpNotFound();
                }

                Mapper.Map(model, person);

                await Context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            model.Countries.AddRange(Mapper.Map<List<SelectListItem>>(await Context.Countries.OrderBy(c => c.Name).ToListAsync()));
            model.RegionsByCountry = (await Context.Regions.ToListAsync())
                .GroupBy(kvp => kvp.CountryId)
                .ToDictionary(grp => grp.Key, grp => grp.OrderBy(r => r.Name).Select(r => new SelectListItem { Text = r.Name, Value = r.Abbreviation }).ToList());

            return View(model);
        }

        public ActionResult Delete(Guid id)
        {
            var person = GetPerson(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<PeopleDeleteModel>(person));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(PeopleDeleteModel model)
        {
            if (ModelState.IsValid)
            {
                var person = GetPerson(model.Id);
                if (person == null)
                {
                    return HttpNotFound();
                }

                Context.People.Remove(person);
                await Context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }


        private Person GetPerson(Guid id)
        {
            return Context.People
                .SingleOrDefault(p => p.Id == id);
        }
    }
}