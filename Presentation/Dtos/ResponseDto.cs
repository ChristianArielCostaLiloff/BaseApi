﻿namespace Presentation.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public object Result { get; set; } = null!;
    }
}
