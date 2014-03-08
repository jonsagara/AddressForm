using System;
using System.Linq;

namespace AddressForm.MvcWeb.Models.Seed
{
    public static class RegionSeeder
    {
        public static void SeedRegions(AddressFormDbContext context)
        {
            SeedRegion(context, Guid.Parse("589e33ef-44bb-47bf-a3ae-d87d40ab9dd9"), "US", "AL", "Alabama");
            SeedRegion(context, Guid.Parse("b9fc7d2f-084d-4090-b4b0-338a434ec665"), "US", "AK", "Alaska");
            SeedRegion(context, Guid.Parse("fb3971b0-c219-407e-96a6-bdff120239fe"), "US", "AS", "American Samoa");
            SeedRegion(context, Guid.Parse("08e94b0c-8774-4245-bd30-06306c22e37a"), "US", "AZ", "Arizona");
            SeedRegion(context, Guid.Parse("5a7f93d6-2fc2-4338-87e1-3ccbd4055cd5"), "US", "AR", "Arkansas");
            SeedRegion(context, Guid.Parse("7a4c7f90-ef22-4b64-998b-3be396414a13"), "US", "CA", "California");
            SeedRegion(context, Guid.Parse("ab8caebb-e506-4465-b0cb-2cd2562d4283"), "US", "CO", "Colorado");
            SeedRegion(context, Guid.Parse("87aa7436-872f-4831-b95e-1657d5b667ed"), "US", "CT", "Connecticut");
            SeedRegion(context, Guid.Parse("04d2a3d9-89e5-49b9-bbce-dbcad5c050ed"), "US", "DE", "Delaware");
            SeedRegion(context, Guid.Parse("7ef365e3-f99d-46c7-8ef3-c039b8cccd91"), "US", "DC", "District Of Columbia");
            SeedRegion(context, Guid.Parse("3f491062-6a80-4261-bc7f-b61a603a582e"), "US", "FM", "Federated States Of Micronesia");
            SeedRegion(context, Guid.Parse("d830feb2-dbc6-47cd-924d-ba269c0647cc"), "US", "FL", "Florida");
            SeedRegion(context, Guid.Parse("0e15f76f-55cf-434f-86f7-449cd436fd26"), "US", "GA", "Georgia");
            SeedRegion(context, Guid.Parse("b70cd3c0-4ca9-4ec8-adf0-d4d53c0e9a01"), "US", "GU", "Guam");
            SeedRegion(context, Guid.Parse("18ecee5c-d845-4b1c-8092-ccbc6b8a9d43"), "US", "HI", "Hawaii");
            SeedRegion(context, Guid.Parse("ca8fbd59-c025-44a4-a0e8-09294583ea4d"), "US", "ID", "Idaho");
            SeedRegion(context, Guid.Parse("cdcca994-e485-4267-9b54-dadb68be65cf"), "US", "IL", "Illinois");
            SeedRegion(context, Guid.Parse("16f33a5f-ebf8-452b-8451-078917808823"), "US", "IN", "Indiana");
            SeedRegion(context, Guid.Parse("365f4500-3992-47db-8393-ae2a50619499"), "US", "IA", "Iowa");
            SeedRegion(context, Guid.Parse("6a536d46-2ba9-4371-bb0f-b81de3809e36"), "US", "KS", "Kansas");
            SeedRegion(context, Guid.Parse("e46cd795-de79-47b5-8a70-a7625523bf0e"), "US", "KY", "Kentucky");
            SeedRegion(context, Guid.Parse("13495edd-d4dd-459e-ad10-a495142e4585"), "US", "LA", "Louisiana");
            SeedRegion(context, Guid.Parse("e93389c2-c0ef-4309-99bc-a469750feee9"), "US", "ME", "Maine");
            SeedRegion(context, Guid.Parse("f8a5b9c7-e268-4e60-a294-8d191bd4388c"), "US", "MH", "Marshall Islands");
            SeedRegion(context, Guid.Parse("b41ebd92-e84f-43dd-9bd7-09fdd9c115a5"), "US", "MD", "Maryland");
            SeedRegion(context, Guid.Parse("3bb3b52b-db38-4262-b29c-4a604c08faca"), "US", "MA", "Massachusetts");
            SeedRegion(context, Guid.Parse("94259940-6a62-49ef-a818-8ebaba8da5f8"), "US", "MI", "Michigan");
            SeedRegion(context, Guid.Parse("ffbb6573-cf6a-4bb6-b81a-f0ce99a3badf"), "US", "MN", "Minnesota");
            SeedRegion(context, Guid.Parse("b66e60a0-35b6-4a4d-bc2a-27d78ba05d99"), "US", "MS", "Mississippi");
            SeedRegion(context, Guid.Parse("1c663f4c-46fc-4477-83d0-0e020f8ec7a4"), "US", "MO", "Missouri");
            SeedRegion(context, Guid.Parse("06f3e827-ed78-4cc6-9691-60fb41917917"), "US", "MT", "Montana");
            SeedRegion(context, Guid.Parse("e27d9611-8584-4e28-938a-cefeb46d3acc"), "US", "NE", "Nebraska");
            SeedRegion(context, Guid.Parse("df798930-c29b-4703-8aef-f3748cae26a6"), "US", "NV", "Nevada");
            SeedRegion(context, Guid.Parse("37cf4719-7861-47af-8ea7-0663cb4085df"), "US", "NH", "New Hampshire");
            SeedRegion(context, Guid.Parse("8c5c7b95-18a9-4fc3-84a9-a65b53cacc0d"), "US", "NJ", "New Jersey");
            SeedRegion(context, Guid.Parse("074ac577-90fb-462e-87e1-2e606096e3e6"), "US", "NM", "New Mexico");
            SeedRegion(context, Guid.Parse("148da95c-41ca-4896-8f86-20ea7e85021d"), "US", "NY", "New York");
            SeedRegion(context, Guid.Parse("38445caa-b000-4316-ad53-ad9d812d2c23"), "US", "NC", "North Carolina");
            SeedRegion(context, Guid.Parse("c08aa517-674c-42b3-9913-8cefa68f2a51"), "US", "ND", "North Dakota");
            SeedRegion(context, Guid.Parse("682f796d-e603-4572-8087-3ceb9b6a1b0d"), "US", "MP", "Northern Mariana Islands");
            SeedRegion(context, Guid.Parse("a9dcd797-e0a9-48ce-9ea5-3768923c266a"), "US", "OH", "Ohio");
            SeedRegion(context, Guid.Parse("e24c9d4a-0acf-4f37-ab09-89a5e90ee13f"), "US", "OK", "Oklahoma");
            SeedRegion(context, Guid.Parse("bf8dfe44-8fbd-4415-944b-13fae8ccb369"), "US", "OR", "Oregon");
            SeedRegion(context, Guid.Parse("534c61c6-42f2-45cf-bb61-6d43fec49ea5"), "US", "PW", "Palau");
            SeedRegion(context, Guid.Parse("b16dc043-9629-4146-b1fa-fb415bc49495"), "US", "PA", "Pennsylvania");
            SeedRegion(context, Guid.Parse("b13fd969-ed2a-48f2-b356-9524e8511a4c"), "US", "PR", "Puerto Rico");
            SeedRegion(context, Guid.Parse("36a795ef-f631-4b75-a660-caebf81c0904"), "US", "RI", "Rhode Island");
            SeedRegion(context, Guid.Parse("caac44e6-439d-49d2-b977-d7c4fc35e4ee"), "US", "SC", "South Carolina");
            SeedRegion(context, Guid.Parse("1c8b651e-86f9-44ef-9038-41ec32ee8c62"), "US", "SD", "South Dakota");
            SeedRegion(context, Guid.Parse("14a85ce9-87cc-4846-a011-95e23d2a4f3a"), "US", "TN", "Tennessee");
            SeedRegion(context, Guid.Parse("28cdb326-9a88-4c68-ac7a-7e7e2b5a73c3"), "US", "TX", "Texas");
            SeedRegion(context, Guid.Parse("408cecce-acce-44fd-823f-647280035cc9"), "US", "UT", "Utah");
            SeedRegion(context, Guid.Parse("5012ea30-1da9-4f09-8664-d35c3a1e6090"), "US", "VT", "Vermont");
            SeedRegion(context, Guid.Parse("b283b79a-04bd-46ab-bf5c-2c95a3acc136"), "US", "VI", "Virgin Islands");
            SeedRegion(context, Guid.Parse("76888d16-2244-4d1e-9d56-38e0d2b5ccfc"), "US", "VA", "Virginia");
            SeedRegion(context, Guid.Parse("ba462f71-3c99-4440-8f76-319f66f4ff6e"), "US", "WA", "Washington");
            SeedRegion(context, Guid.Parse("90ef6e7b-c447-4717-ac25-1b05e3687d6b"), "US", "WV", "West Virginia");
            SeedRegion(context, Guid.Parse("2d590cdc-e7fd-44d5-9951-12b8943ceac5"), "US", "WI", "Wisconsin");
            SeedRegion(context, Guid.Parse("ef7f0f8a-a6c2-499e-b3a7-78f89db1c2b9"), "US", "WY", "Wyoming");
            SeedRegion(context, Guid.Parse("80c7e4f2-173a-4b1e-9ac3-e11776a2249e"), "CA", "AB", "Alberta");
            SeedRegion(context, Guid.Parse("6281bb42-1304-417e-a2f0-903401314561"), "CA", "BC", "British Columbia");
            SeedRegion(context, Guid.Parse("49962269-2831-4f1c-9b99-e3f39b5a6932"), "CA", "MB", "Manitoba");
            SeedRegion(context, Guid.Parse("681802b8-13f6-49b0-8a56-711449c36bd7"), "CA", "NB", "New Brunswick");
            SeedRegion(context, Guid.Parse("f7672c7e-a2c0-4784-9c06-a56991b436dc"), "CA", "NL", "Newfoundland and Labrador");
            SeedRegion(context, Guid.Parse("ef58410a-906e-4ba5-a154-96eb14f77fb2"), "CA", "NS", "Nova Scotia");
            SeedRegion(context, Guid.Parse("3b542f92-7f4f-4d9c-bc0b-abd7d02de319"), "CA", "NT", "Northwest Territories");
            SeedRegion(context, Guid.Parse("64de0d4e-be9d-4d84-aefa-ea33f4b26b55"), "CA", "NU", "Nunavut");
            SeedRegion(context, Guid.Parse("af77711f-ec46-46ee-a65d-12cf16973af8"), "CA", "ON", "Ontario");
            SeedRegion(context, Guid.Parse("41d3700a-b0b8-4380-91c9-a8b559fb3bb3"), "CA", "PE", "Prince Edward Island");
            SeedRegion(context, Guid.Parse("e844eae1-1b94-4ff6-8457-35d5864434a6"), "CA", "QC", "Quebec");
            SeedRegion(context, Guid.Parse("c9315a9b-7be3-4b58-ad98-fec697560d01"), "CA", "SK", "Saskatchewan");
            SeedRegion(context, Guid.Parse("e1268544-c173-40df-8042-2c2a0ca59d7a"), "CA", "YT", "Yukon");

        }

        private static void SeedRegion(AddressFormDbContext context, Guid id, string countryId, string abbreviation, string name)
        {
            var region = context.Regions.SingleOrDefault(r => r.Id == id);
            if (region != null)
            {
                return;
            }

            region = new Region
            {
                Id = id,
                CountryId = countryId,
                Abbreviation = abbreviation,
                Name = name
            };

            context.Regions.Add(region);
            context.SaveChanges();
        }
    }
}