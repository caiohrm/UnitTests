using System;
namespace UnitTest
{
	public class CustomService
	{
		public CustomService(ICustomServiceRepository customServiceRepository)
		{
            CustomServiceRepository = customServiceRepository;
        }

        public ICustomServiceRepository CustomServiceRepository { get; }


        public string ConsultTestReturn(string name)
        {
                return $"{this.CustomServiceRepository.TestReturn()} {name}";
        }
    }
}

